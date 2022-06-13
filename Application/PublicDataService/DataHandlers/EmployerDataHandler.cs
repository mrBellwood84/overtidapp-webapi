using Domain.Employer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Persistence;

namespace Application.PublicDataService.DataHandlers
{
    public class EmployerDataHandler
    {
        private readonly PublicDataContext _context;
        private readonly IMemoryCache _memoryCache;

        private readonly string _keyShort = "employerShort";
        private readonly string _keyFull = "employerLong";
        private readonly string _keySug = "employerEditSuggestion";


        public EmployerDataHandler(PublicDataContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }
        

        /// <summary>
        /// Get list with employer data short info
        /// </summary>
        public async Task<List<EmployerShortDto>> GetEmployerShortInfo()
        {
            var employerList = _memoryCache.Get(_keyShort) as List<EmployerShortDto>;

            if (employerList == null)
            {
                employerList = await HandleEmployerShortInfoListQuery();

                _memoryCache.Set(_keyShort, employerList);
            }

            return employerList;
        }


        /// <summary>
        /// Get list with full employer data
        /// </summary>
        public async Task<List<EmployerEntity>> GetEmployerFullDataList()
        {
            var employerList = _memoryCache.Get(_keyFull) as List<EmployerEntity>;

            if (employerList == null)
            {
                employerList = await HandleEmployerFullInfoListQuery();
                _memoryCache.Set(_keyFull, employerList);
            }

            return employerList;
        }


        /// <summary>
        /// Get a single employer full entity by id query
        /// </summary>
        public async Task<EmployerEntity> GetSingleEmployerById(Guid id)
        {
            var emp = await _context.Employers.SingleAsync(x => x.Id == id);
            return emp;
        }


        /// <summary>
        /// Get all employer edit suggestions added by users
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployerEditSuggestionEntity>> GetEmployerEditSuggestionList()
        {
            var res = _memoryCache.Get(_keySug) as List<EmployerEditSuggestionEntity>;

            if (res == null)
            {
                res = await HandleSuggestionsQuery();
                _memoryCache.Set(_keySug, res);
            }

            return res;
        }


        /// <summary>
        /// Create new employer entity. Only stores data directly downloaded from public records.
        /// Any requested changes is stored as a change request.
        /// </summary>
        /// <remarks>
        /// Change requests can be handled by admin in frontend application
        /// </remarks>
        public async Task<EmployerEntity> AddNewEmployer(EmployerCreateNewDto newEmployer)
        {
            var employer = new EmployerEntity
            {
                Id = Guid.NewGuid(),

                NameLegal = newEmployer.LegalData.Name,
                NameUsed = newEmployer.LegalData.Name,

                OrganizationNumber = newEmployer.LegalData.OrganizationNumber,

                AddressLegal = newEmployer.LegalData.Address,
                AddressUsed = newEmployer.LegalData.Address,

                PostAreaLegal = newEmployer.LegalData.PostArea,
                PostAreaUsed = newEmployer.LegalData.PostArea,

                ZipCodeLegal = newEmployer.LegalData.ZipCode,
                ZipCodeUsed = newEmployer.LegalData.ZipCode,

                RegionLegal = newEmployer.LegalData.Region,
                RegionUsed = newEmployer.LegalData.Region,

                CollectiveAgreementId = null,

                DateAdded = DateTime.UtcNow,
                AddedBy = "System",
                DateLastUpdate = DateTime.UtcNow,
                LastUpdateBy = "System",
            };

            bool nameChange = newEmployer.LegalData.Name != newEmployer.ChangeSuggestion.Name;
            bool addressChange = newEmployer.LegalData.Address != newEmployer.ChangeSuggestion.Address;
            bool postAreaChange = newEmployer.LegalData.PostArea != newEmployer.ChangeSuggestion.PostArea;
            bool zipCodeChange = newEmployer.LegalData.ZipCode != newEmployer.ChangeSuggestion.ZipCode;
            bool regionChange = newEmployer.LegalData.Region != newEmployer.ChangeSuggestion.Region;
            bool caChange = newEmployer.LegalData.HasAgreement != newEmployer.ChangeSuggestion.HasAgreement;

            if (nameChange || addressChange || postAreaChange || zipCodeChange || regionChange || caChange)
            {
                var changeSuggestion = new EmployerEditSuggestionEntity
                {
                    Id = Guid.NewGuid(),
                    EmployerId = employer.Id,
                    Name = newEmployer.ChangeSuggestion.Name,
                    OrganizationNumber = newEmployer.ChangeSuggestion.OrganizationNumber,
                    Address = newEmployer.ChangeSuggestion.Address,
                    PostArea = newEmployer.ChangeSuggestion.PostArea,
                    ZipCode = newEmployer.ChangeSuggestion.ZipCode,
                    Region = newEmployer.ChangeSuggestion.Region,
                    HasAgreement = newEmployer.ChangeSuggestion.HasAgreement,
                    RequestedBy = newEmployer.ChangeSuggestion.RequestedBy,
                    Resolved = false,
                };

                employer.HasChangeRequest = true;
                await _context.EmployerEditSuggestions.AddAsync(changeSuggestion);
            }


            await _context.Employers.AddAsync(employer);
            await _context.SaveChangesAsync();

            await UpdateMemoryCache();

            return employer;
        }

        /// <summary>
        /// Check if user already has submittet a change request for entity.
        /// </summary>
        /// <returns>
        /// True if user has submitted a change request
        /// </returns>
        public async Task<bool> CheckUserSuggestion(Guid employerId, string username)
        {
            var result = await _context.EmployerEditSuggestions.Where(x => x.RequestedBy == username && x.EmployerId == employerId && x.Resolved == false).SingleAsync();
            return result != null;
        }

        /// <summary>
        /// Check if chnage suggestion contain any real changes
        /// </summary>
        /// <returns>True if dto contain real change to employer entity</returns>
        public async Task<bool> CheckValidChangeSuggestion(EmployerEditSuggestionDto dto)
        {
            var entity = await _context.Employers.SingleAsync(x => x.Id == dto.EmployerId);

            bool nameChange = entity.NameUsed != dto.Name;
            bool addressChange = entity.AddressUsed != dto.Address;
            bool postAreaChange = entity.PostAreaUsed != dto.PostArea;
            bool zipCodeChange = entity.ZipCodeUsed != dto.ZipCode;
            bool regionChange = entity.RegionUsed != dto.Region;

            if (nameChange || addressChange || postAreaChange || zipCodeChange || regionChange || dto.HasAgreement) return true;
            return false;
        }

        /// <summary>
        /// Add edit sugggestion to database
        /// </summary>
        /// <param name="suggestion"></param>
        /// <returns></returns>
        public async Task AddEmployerEditSuggestion(EmployerEditSuggestionDto suggestion)
        {
            var suggestionEntity = new EmployerEditSuggestionEntity
            {
                Id = Guid.NewGuid(),
                EmployerId = suggestion.EmployerId ?? Guid.Empty,
                Name = suggestion.Name,
                OrganizationNumber = suggestion.OrganizationNumber,
                Address = suggestion.Address,
                PostArea = suggestion.PostArea,
                ZipCode= suggestion.ZipCode,
                Region = suggestion.Region,
                HasAgreement = suggestion.HasAgreement,
                Resolved = false,
                RequestedBy = suggestion.RequestedBy,
            };

            var employerEntity = await _context.Employers.Where(x => x.Id == suggestion.EmployerId).FirstOrDefaultAsync();
            employerEntity!.HasChangeRequest = true;

            await _context.EmployerEditSuggestions.AddAsync(suggestionEntity);

            await _context.SaveChangesAsync();

            await UpdateMemoryCache();
        }


        /// <summary>
        /// Update employer entity based on user suggestions, handled by admin
        /// </summary>
        /// <param name="requestDto"></param>
        public async Task<EmployerEntity> UpdateEmployer(EmployerEditRequestDto requestDto)
        {
            var employer = await GetSingleEmployerById(requestDto.EmployerId);

            employer.NameUsed = requestDto.Name;
            employer.OrganizationNumber = requestDto.OrganizationNumber;

            employer.AddressUsed = requestDto.Address;
            employer.PostAreaUsed = requestDto.PostArea;
            employer.ZipCodeUsed = requestDto.ZipCode;
            employer.RegionUsed = requestDto.Region;

            employer.CollectiveAgreementId = requestDto.CollectiveAgreementId;

            employer.HasChangeRequest = false;

            employer.DateLastUpdate = DateTime.UtcNow;
            employer.LastUpdateBy = requestDto.EditedBy;

            

            var changeRequests = await _context.EmployerEditSuggestions.Where(x => x.EmployerId == requestDto.EmployerId).ToListAsync();
            changeRequests.ForEach(x => x.Resolved = true);

            await _context.SaveChangesAsync();

            await UpdateMemoryCache();

            return employer;
        }


        /// <summary>
        /// Delete employer and any related change suggestions
        /// </summary>
        /// <param name="employerId"></param>
        public async Task DeleteEmployer(Guid employerId)
        {
            var emp = await GetSingleEmployerById(employerId);
            var sug = await _context.EmployerEditSuggestions.Where(x => x.EmployerId == employerId).ToArrayAsync();

            _context.Employers.Remove(emp);
            _context.EmployerEditSuggestions.RemoveRange(sug);
            
            await _context.SaveChangesAsync();

            await UpdateMemoryCache();
        }


        /// <summary>
        /// Delete unnecessary or unwanted change suggestions by suggestion id
        /// </summary>
        public async Task DeleteSuggestionById(Guid suggestionId)
        {
            var item = await _context.EmployerEditSuggestions.SingleAsync(x => x.Id == suggestionId);
            _context.Remove(item);
            await _context.SaveChangesAsync();

            await UpdateMemoryCache();
        }


        /// <summary>
        /// Get short employer short info list by query
        /// </summary>
        private async Task<List<EmployerShortDto>> HandleEmployerShortInfoListQuery()
        {
            var employerList = await (from emp in _context.Employers
                                  select new EmployerShortDto
                                  {
                                      Id = emp.Id,
                                      Name = emp.NameUsed,
                                      OrganizationNumber = emp.OrganizationNumber,
                                      Region = emp.RegionUsed,
                                      HasAgreement = emp.CollectiveAgreementId != null

                                  }).ToListAsync();

            return employerList;

        }

        /// <summary>
        /// Query for list of all employers entites, all info
        /// </summary>
        private async Task<List<EmployerEntity>> HandleEmployerFullInfoListQuery()
        {
            return await _context.Employers.ToListAsync();
        }

        /// <summary>
        /// Return list of all employer edit requests as db entities
        /// </summary>
        private async Task<List<EmployerEditSuggestionEntity>> HandleSuggestionsQuery()
        {
            var res = await _context.EmployerEditSuggestions.ToListAsync();
            return res;
        }

        /// <summary>
        /// Query all data and update memory cache
        /// </summary>
        /// <returns></returns>
        private async Task UpdateMemoryCache()
        {
            var shortInfo = await HandleEmployerShortInfoListQuery();
            var fullInfo = await HandleEmployerFullInfoListQuery();
            var suggestions = await HandleSuggestionsQuery();

            _memoryCache.Set(_keyShort, shortInfo);
            _memoryCache.Set(_keyFull, fullInfo);
            _memoryCache.Set(_keySug, suggestions);
        }
    }
}
