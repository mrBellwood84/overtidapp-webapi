using Application.PublicDataService.DataHandlers;

namespace Application.PublicDataService
{
    public interface IPublicDataService
    {
        CollectiveAgreementDataHandler CollectiveAgreementData { get; }
        EmployerDataHandler EmployerData { get; }
    }
}