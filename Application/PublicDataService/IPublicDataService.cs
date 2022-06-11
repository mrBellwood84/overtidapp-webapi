using Application.PublicDataService.DataHandlers;

namespace Application.PublicDataService
{
    public interface IPublicDataService
    {
        AmlDataHandler AmlData { get; set; }
        CollectiveAgreementDataHandler CollectiveAgreementData { get; }
        EmployerDataHandler EmployerData { get; }
    }
}