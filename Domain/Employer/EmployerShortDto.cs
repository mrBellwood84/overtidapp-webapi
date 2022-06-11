namespace Domain.Employer
{
    /// <summary>
    /// Employer short info data
    /// </summary>
    public class EmployerShortDto
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Employer commonly used name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Employer Organization number
        /// </summary>
        public string OrganizationNumber { get; set; }

        /// <summary>
        /// City or region
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// True if employer bound by collective agreement
        /// </summary>
        public bool HasAgreement { get; set; }
    }
}
