﻿using Domain.Employment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Persistence;

namespace Application.PublicDataService.DataHandlers
{
    public class EmployerDataHandler
    {
        private readonly PublicDataContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly string _cacheKey = "Employers";


        /// <summary>
        /// Retrive cache key
        /// </summary>
        public string CacheKey { get => _cacheKey; }


        public EmployerDataHandler(PublicDataContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<List<Employer>> GetAllEmployers()
        {
            var list = await _context.Employers.ToListAsync();
            _memoryCache.Set(_cacheKey, list);
            return list;
        }

        public async Task<Employer> AddNewEmployer(NewEmployerRequest request)
        {
            // create new employer entity
            var employer = new Employer
            {
                Id                  = Guid.NewGuid(),
                Name                = request.Name,
                NameOfficial        = request.Name,
                OrganizationNumber  = request.OrganizationNumber,
                Address             = request.Address,
                AddressOfficial     = request.Address,
                PostalArea          = request.PostalArea,
                PostalAreaOfficial  = request.PostalArea,
                ZipCode             = request.ZipCode,
                ZipCodeOfficial     = request.ZipCode,
                County              = request.County,
                CountyOfficial      = request.County,
                HaveEditRequest     = false,
                DataSource          = request.DataSource,
                DateAdded           = DateTime.UtcNow,
                DateLastEdit        = DateTime.UtcNow,
                EditedBy            = "System",
            };



            // check if there is any difference in values for edit request
            bool haveEditRequest  = (request.Name       != request.EditRequest.Name)        ||
                                    (request.Address    != request.EditRequest.Address)     ||
                                    (request.PostalArea != request.EditRequest.PostalArea)  ||
                                    (request.ZipCode    != request.EditRequest.ZipCode)     ||
                                    (request.County     != request.EditRequest.County)      ||
                                    (request.EditRequest.HasCollectiveAgreement);
            
            if (haveEditRequest)
            {
                var editRequest         = request.EditRequest;

                editRequest.Id          = Guid.NewGuid();
                editRequest.EmployerId  = employer.Id;

                employer.HaveEditRequest = true;
                
                await _context.EmployersEditRequests.AddAsync(editRequest);
            }


            // add employer to database
            await _context.Employers.AddAsync(employer);
            // save changes
            await _context.SaveChangesAsync();
            // run this to update cache
            await GetAllEmployers();

            return employer;
        }

        public async Task<List<EmployerEditRequest>> GetAllEditRequests()
        {
            var list  = await _context.EmployersEditRequests.Where(x => x.Resolved == false).ToListAsync();
            return list;
        }
    }
}
