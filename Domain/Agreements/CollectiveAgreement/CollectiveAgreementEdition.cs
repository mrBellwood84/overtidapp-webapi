namespace Domain.Agreements.CollectiveAgreement
{
    public class CollectiveAgreementEdition
    {
        public Guid Id { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime? Expired { get; set; }

        public List<SalaryTable> SalaryTables { get; set; }
    }
}
