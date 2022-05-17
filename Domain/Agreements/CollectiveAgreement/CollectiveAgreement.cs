namespace Domain.Agreements.CollectiveAgreement
{
    public class CollectiveAgreement
    {
        public Guid Id { get; set; }

        public string AgreementName { get; set; }

        public string EmployeeOrganization { get; set; }

        public string EmployerOrganization { get; set; }

        public List<CollectiveAgreementEdition>  Editions { get; set; }
    }
}
