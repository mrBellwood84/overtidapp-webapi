namespace Domain.Employment
{
    /// <summary>
    /// Model for editing employer request, used for DTO and data entity
    /// Only user with admin role can change employer data!
    /// </summary>
    public class EmployerEditRequest
    {
        /// <summary>
        /// EntityId
        /// </summary>
        public Guid? Id { get; set; }

        public Guid? EmployerId { get; set; }
        /// <summary>
        /// Requested new name
        /// </summary>
        public string Name { get; set; }

# nullable enable
        /// <summary>
        /// Requested new organization number
        /// </summary>
        public string? OrganizaionNumber { get; set; }
# nullable disable

        /// <summary>
        /// Requested new address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Requsted Postal area
        /// </summary>
        public string PostalArea { get; set; }

        /// <summary>
        /// Requested zip code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Requested county
        /// </summary>
        public string County { get; set; }


        /// <summary>
        /// Requested check Collective agreement
        /// </summary>
        public bool HasCollectiveAgreement { get; set; }

        /// <summary>
        /// Username of user requesting
        /// </summary>
        public string RequestedBy { get; set; }

        /// <summary>
        /// true if handled
        /// </summary>
        public bool Resolved { get; set; }
    }
}
