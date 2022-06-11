namespace Domain.Employer
{
    /// <summary>
    /// Dto for suggesting changes to an employer entity.
    /// </summary>
    /// <remarks>
    /// Use EmployerEditRequestDto for http update requests!
    /// </remarks>
    public class EmployerEditSuggestionDto
    {
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
        public string PostalArea { get; set; }

        /// <summary>
        /// ZipCode to be changed
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Region to be changed
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// True if an agreement should be added
        /// </summary>
        public bool HasAgreement { get; set; }

        /// <summary>
        /// Username of user requesting change
        /// </summary>
        public string RequestedBy { get; set; }
    }
}
