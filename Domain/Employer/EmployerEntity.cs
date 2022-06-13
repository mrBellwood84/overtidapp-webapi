namespace Domain.Employer
{

    /// <summary>
    ///  Db entity model for employer entity
    /// </summary>
    /// <remarks>
    /// Since legal documents often contain diffent name and address for place of employment,
    ///     name and address fields have a legal and a used variant, where "used" should define the acctual place of employment.
    /// </remarks>
    public class EmployerEntity
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of employer as used in legal documents / public records
        /// </summary>
        public string NameLegal { get; set; }

        /// <summary>
        /// The commonly used name for business / employer.
        /// </summary>
        public string NameUsed { get; set; }


        /// <summary>
        /// Organization number for employer
        /// </summary>
        public string OrganizationNumber { get; set; }

        /// <summary>
        /// Address of employer as in public / legal records
        /// </summary>
        public string AddressLegal { get; set; }

        /// <summary>
        /// Actual business address
        /// </summary>
        public string AddressUsed { get; set; }


        /// <summary>
        /// Post area for employer as in public / legal records
        /// </summary>
        public string PostAreaLegal { get; set; }

        /// <summary>
        /// Actual postal area for business
        /// </summary>
        public string PostAreaUsed { get; set; }


        /// <summary>
        /// Zipcode for employer as in public / legal records
        /// </summary>
        public string ZipCodeLegal { get; set; }

        /// <summary>
        /// Actual zipcode for business
        /// </summary>
        public string ZipCodeUsed { get; set; }


        /// <summary>
        /// County / Region for employer as in public / legal records
        /// </summary>
        public string RegionLegal { get; set; }

        /// <summary>
        /// Actual county / region for business
        /// </summary>
        public string RegionUsed { get; set; }



        /// <summary>
        /// Id for collective agreeement if any, else null
        /// </summary>
        public Guid? CollectiveAgreementId { get; set; }

        /// <summary>
        /// Set true if entity has an attached change request
        /// </summary>
        public bool HasChangeRequest { get; set; }


        /// <summary>
        /// Timestamp of entity added
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// username of user who added entity
        /// </summary>
        public string AddedBy { get; set; }

        /// <summary>
        /// Timestamp of last entity update
        /// </summary>
        public DateTime DateLastUpdate { get; set; }

        /// <summary>
        /// username of user who last updated entity
        /// </summary>
        public string LastUpdateBy { get; set; }
    }
}
