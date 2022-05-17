namespace Domain.Employment
{
    /// <summary>
    /// New employer request dto
    /// </summary>
    public class NewEmployerRequest
    {
        /// <summary>
        /// Official name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Organization number
        /// </summary>
        public string OrganizationNumber { get; set; }

        /// <summary>
        /// Official Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Official PostalArea
        /// </summary>
        public string PostalArea { get; set; }

        /// <summary>
        /// Official ZipCode
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Official County
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// Source of data added to api
        /// </summary>
        public string DataSource { get; set; }

        /// <summary>
        /// Request for any change
        /// </summary>
        public EmployerEditRequest EditRequest { get; set; }

    }
}
