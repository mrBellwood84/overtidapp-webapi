namespace Domain.Agreements.CollectiveAgreement
{
    /// <summary>
    /// Entity model for collective agreements
    /// </summary>
    public class CollectiveAgreementEntity
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of agreement
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Employee side of agreement
        /// </summary>
        public string EmployeeOrganization { get; set; }


        /// <summary>
        /// Employer side of agreement
        /// </summary>
        public string EmployerOrganization { get; set; }

        /// <summary>
        /// List of Editions of agreement, usually changed every second year.
        /// </summary>
        public List<CollectiveAgreementEdition> Editions { get; set; }
    }
}
