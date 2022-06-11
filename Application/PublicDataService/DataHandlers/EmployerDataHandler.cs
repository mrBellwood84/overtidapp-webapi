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

                PostAreaLegal = newEmployer.LegalData.PostalArea,
                PostAreaUsed = newEmployer.LegalData.PostalArea,

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

            if (newEmployer.LegalData != newEmployer.ChangeSuggestion)
            {
                var changeSuggestion = new EmployerEditSuggestionEntity
                {
                    Id = Guid.NewGuid(),
                    EmployerId = employer.Id,
                    Name = newEmployer.ChangeSuggestion.Name,
                    Address = newEmployer.ChangeSuggestion.Address,
                    PostalArea = newEmployer.ChangeSuggestion.PostalArea,
                    ZipCode = newEmployer.ChangeSuggestion.ZipCode,
                    Region = newEmployer.ChangeSuggestion.Region,
                    HasAgreement = newEmployer.ChangeSuggestion.HasAgreement,
                    RequestedBy = newEmployer.ChangeSuggestion.RequestedBy,
                    Resolved = false,
                };

                await _context.EmployerEditSuggestions.AddAsync(changeSuggestion);
            }

            await _context.Employers.AddAsync(employer);
            await _context.SaveChangesAsync();

            await UpdateMemoryCache();

            return employer;
        }


        /// <summary>
        /// Add edit sugggestion to database
        /// </summary>
        /// <param name="suggestion"></param>
        /// <returns></returns>
        public async Task AddEmployerEditSuggestion(EmployerEditSuggestionDto suggestion)
        {
            var entity = new EmployerEditSuggestionEntity
            {
                Id = Guid.NewGuid(),
                EmployerId = suggestion.EmployerId,
                Name = suggestion.Name,
                OrganizationNumber = suggestion.OrganizationNumber,
                Address = suggestion.Address,
                PostalArea = suggestion.PostalArea,
                ZipCode= suggestion.ZipCode,
                Region = suggestion.Region,
                HasAgreement = suggestion.HasAgreement,
                Resolved = false,
                RequestedBy = suggestion.RequestedBy,
            };

            await _context.EmployerEditSuggestions.AddAsync(entity);

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
            employer.AddressUsed = requestDto.Address;
            employer.PostAreaUsed = requestDto.PostalArea;
            employer.ZipCodeUsed = requestDto.ZipCode;
            employer.RegionUsed = requestDto.Region;
            
            employer.CollectiveAgreementId = requestDto.CollectiveAgreementId;

            var request = await _context.EmployerEditSuggestions.SingleAsync(x => x.Id == requestDto.RequestId);
            request.Resolved = true;

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
        /// Delete unnecessary or unwanted suggestions by username if spammed or flooded by requests...
        /// </summary>
        /// <param name="userName"></param>
        public async Task DeleteSuggestionByUserName (string userName)
        {
            var range = await _context.EmployerEditSuggestions.Where(x => x.RequestedBy == userName).ToArrayAsync();
            _context.RemoveRange(range);

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
