using Domain.Agreements.Aml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Persistence;

namespace Application.PublicDataService.DataHandlers
{
    /// <summary>
    /// Handle working environment act data in db, 
    /// </summary>
    public class AmlDataHandler
    {
        private readonly IMemoryCache _cache;
        private readonly PublicDataContext _context;
        private readonly string _cacheKey = "Aml";

        // public string CacheKey { get => _cacheKey; }

        // constructor
        public AmlDataHandler(PublicDataContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        /// <summary>
        /// Get full working environment act ruleset as entity from database
        /// </summary>
        /// <remarks>
        /// Heavy query, data stored in memory cache
        /// </remarks>
        public async Task<AmlEntity> GetAmlEntity()
        {
            var aml = _cache.Get(_cacheKey);            

            if (aml == null)
            {
                aml = await _context.Aml

                    .Include(e => e.WorkhoursDay)
                        .ThenInclude(f => f.Reference)            
                    .Include(e => e.WorkhoursDayMaxLegal)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.WorkhoursDayIndividual)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.WorkhoursDaySpecial)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.WorkhoursDaySpecialMaxLegal)
                        .ThenInclude(f => f.Reference)

                    .Include(e => e.WorkhoursWeek)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.WorkhoursWeekShift)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.WorkhoursWeekIndividual)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.WorkhoursWeekSpecial)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.WorkhoursWeekAverage)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.WorkhoursWeekMaxLegal)
                        .ThenInclude(f => f.Reference)

                    .Include(e => e.MaxOvertimeWeek)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.MaxOvertimeWeekSpecial)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.MaxOvertimeMonth)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.MaxOvertimeMonthSpecial)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.MaxOvertimeYear)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.MaxOvertimeYearSpecial)
                        .ThenInclude(f => f.Reference)

                    .Include(e => e.WorkfreeDay)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.WorkfreeDaySpecial)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.WorkfreeWeek)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.WorkfreeWeekSpecial)
                        .ThenInclude(f => f.Reference)

                    .Include(e => e.OvertimeDefinition)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.SupplementRate)
                        .ThenInclude(f => f.Reference)
                    .Include(e => e.SundayOff)
                        .ThenInclude(f => f.Reference)

                    .AsSplitQuery()
                    .FirstOrDefaultAsync();

                _cache.Set(_cacheKey, aml);
            }

            return (AmlEntity)aml!;
        }

    }
}
