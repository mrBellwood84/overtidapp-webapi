using Domain.Agreements.CollectiveAgreement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Persistence;

namespace Application.PublicDataService.DataHandlers
{
    public class CollectiveAgreementDataHandler
    {
        private readonly PublicDataContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly string _cacheKey = "CollectiveAgreement";


        /// <summary>
        /// Retrive cache key
        /// </summary>
        public string CacheKey { get => _cacheKey; }


        public CollectiveAgreementDataHandler(PublicDataContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<List<CollectiveAgreement>> GetAll()
        {
            var result = await _context.CollectiveAgreeements
                .Include(e => e.Editions)
                .ThenInclude(f => f.SalaryTables)
                .ThenInclude(g => g.SupplementEvening)
                .Include(e => e.Editions)
                .ThenInclude(f => f.SalaryTables)
                .ThenInclude(g => g.SupplementSaturday)
                .Include(e => e.Editions)
                .ThenInclude(f => f.SalaryTables)
                .ThenInclude(g => g.SupplementSunday)
                .Include(e => e.Editions)
                .ThenInclude(f => f.SalaryTables)
                .ThenInclude(g => g.SupplementNight)
                .Include(e => e.Editions)
                .ThenInclude(f => f.SalaryTables)
                .ThenInclude(g => g.SupplementNightLabour)
                .ToListAsync<CollectiveAgreement>();

            _memoryCache.Set(_cacheKey, result);

            return result;
        }
    }
}
