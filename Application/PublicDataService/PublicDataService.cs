using Application.PublicDataService.DataHandlers;
using Microsoft.Extensions.Caching.Memory;
using Persistence;

namespace Application.PublicDataService
{
    public class PublicDataService : IPublicDataService
    {
        private readonly PublicDataContext _context;
        private readonly IMemoryCache _memoryCache;


        public CollectiveAgreementDataHandler CollectiveAgreementData { get; }
        public EmployerDataHandler EmployerData { get; }


        public PublicDataService(PublicDataContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;

            CollectiveAgreementData = new CollectiveAgreementDataHandler(_context, _memoryCache);
            EmployerData = new EmployerDataHandler(_context, _memoryCache);
        }
    }
}
