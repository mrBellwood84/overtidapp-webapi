using Domain.Agreements.CollectiveAgreement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Persistence;

namespace Application.PublicDataService.DataHandlers
{

    /// <summary>
    /// Handle collective agreement data entitites
    /// </summary>
    public class CollectiveAgreementDataHandler
    {
        private readonly PublicDataContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly string _cacheKey = "collectiveAgreement";


        public CollectiveAgreementDataHandler(PublicDataContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }


        /// <summary>
        /// Return Collective agreement entities as list
        /// </summary>
        /// <remarks>
        /// Query result stored in memory cache
        /// </remarks>
        public async Task<List<CollectiveAgreementEntity>> GetAll()
        {

            var agreementList = _memoryCache.Get(_cacheKey) as List<CollectiveAgreementEntity>;

            if (agreementList == null)
            {
                agreementList = await GetAgreementsQuery();
                _memoryCache.Set(_cacheKey, agreementList);
            }

            return agreementList;

        }


        /// <summary>
        /// Return a collective agreement by id request
        /// </summary>
        /// <param name="id">entity id</param>
        public async Task<CollectiveAgreementEntity> GetSingleById(Guid id)
        {
            var agreement = await _context.CollectiveAgreeements

                .Include(e => e.Editions)
                    .ThenInclude(f => f.MaxHourDefinitions)
                        .ThenInclude(g => g.Reference)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.TimeCalculationRule)
                        .ThenInclude(g => g.Reference)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.OvertimeRegular)
                        .ThenInclude(g => g.Reference)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.OvertimeNight)
                        .ThenInclude(g => g.Reference)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.OvertimeDayOff)
                        .ThenInclude(g => g.Reference)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.OvertimeDayoffPartTime)
                        .ThenInclude(g => g.Reference)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.WageSupplementTable)
                        .ThenInclude(g => g.SupplementEvening)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.WageSupplementTable)
                        .ThenInclude(g => g.SupplementSaturday)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.WageSupplementTable)
                        .ThenInclude(g => g.SupplementSunday)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.WageSupplementTable)
                        .ThenInclude(g => g.SupplementNight)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.WageSupplementTable)
                        .ThenInclude(g => g.SupplementNightLabour)
                .AsSplitQuery()
                .SingleAsync(x => x.Id == id);

            return agreement;
        }

        public async Task UpdateMemoryCache()
        {
            var agreement = await GetAgreementsQuery();
            _memoryCache.Set(_cacheKey, agreement);
        }

        private async Task<List<CollectiveAgreementEntity>> GetAgreementsQuery()
        {
            var agreementList = await _context.CollectiveAgreeements

                .Include(e => e.Editions)
                    .ThenInclude(f => f.MaxHourDefinitions)
                        .ThenInclude(g => g.Reference)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.TimeCalculationRule)
                        .ThenInclude(g => g.Reference)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.OvertimeRegular)
                        .ThenInclude(g => g.Reference)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.OvertimeNight)
                        .ThenInclude(g => g.Reference)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.OvertimeDayOff)
                        .ThenInclude(g => g.Reference)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.OvertimeDayoffPartTime)
                        .ThenInclude(g => g.Reference)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.WageSupplementTable)
                        .ThenInclude(g => g.SupplementEvening)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.WageSupplementTable)
                        .ThenInclude(g => g.SupplementSaturday)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.WageSupplementTable)
                        .ThenInclude(g => g.SupplementSunday)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.WageSupplementTable)
                        .ThenInclude(g => g.SupplementNight)

                .Include(e => e.Editions)
                    .ThenInclude(f => f.WageSupplementTable)
                        .ThenInclude(g => g.SupplementNightLabour)
                .AsSplitQuery()
                .ToListAsync();

            return agreementList;
        }
    }
}
