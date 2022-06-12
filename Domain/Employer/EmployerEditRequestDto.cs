namespace Domain.Employer
{
    /// <summary>
    /// DTO for user suggestions for editing an existing employer.
    /// Data is only used for changing place of employment (used),
    /// legal data from public records will remain as downloaded from public records.
    /// </summary>
    public class EmployerEditRequestDto
    {
        /// <summary>
        /// Entity id for request
        /// </summary>
        public Guid RequestId { get; set; }

        /// <summary>
        /// Employer entity id
        /// </summary>
        public Guid EmployerId { get; set; }

        /// <summary>
        /// Used name to be changed
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Organization number to be changed
        /// </summary>
        public string OrganizationNumber { get; set; }

        /// <summary>
        /// Address to be changed
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Postal area to be changed
        /// </summary>
        public string PostArea { get; set; }

        /// <summary>
        /// ZipCode to be changed
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Region to be changed
        /// </summary>
        public string Region { get; set; }

#nullable enable
        /// <summary>
        /// True if an agreement should be added
        /// </summary>
        public Guid? CollectiveAgreementId { get; set; }
#nullable disable

        /// <summary>
        /// Username of user requesting change
        /// </summary>
        public string EditedBy { get; set; }
    }
}

