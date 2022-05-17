using Domain.Agreements;
using Domain.Agreements.CollectiveAgreement;

namespace Domain.Employment
{
    /// <summary>
    /// Model for employer data
    /// </summary>
    public class Employer
    {

        /// <summary>
        /// Entity id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of employer / company
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Offical name as registred in public records
        /// </summary>
        public string NameOfficial { get; set; }

        /// <summary>
        /// Employer organization number
        /// </summary>
        public string OrganizationNumber { get; set; }


        /// <summary>
        /// Address of employer
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Official address as registred in public records
        /// </summary>
        public string AddressOfficial { get; set; } 

        /// <summary>
        /// Postal area
        /// </summary>
        public string PostalArea { get; set; }
        /// <summary>
        /// Official postal area as registed in public records
        /// </summary>
        public string PostalAreaOfficial { get; set; }

        /// <summary>
        /// Zipcode
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// Official ZipCode as registred in public records
        /// </summary>
        public string ZipCodeOfficial { get; set; }

        /// <summary>
        /// County / region
        /// </summary>
        public string County { get; set; }
        /// <summary>
        /// Official County / region as registred in public records
        /// </summary>
        public string CountyOfficial { get; set; }


        /// <summary>
        /// Collective agreement if any
        /// </summary>
        public Guid? CollectiveAgreeementId { get; set; }

#nullable enable
        /// <summary>
        /// Collection of special agreements if any
        /// </summary>
        public List<SpecialAgreement>? SpecialAgreements { get; set; }
#nullable disable

        /// <summary>
        /// True if there is an active edit request for item
        /// </summary>
        public bool HaveEditRequest { get; set; }

        /// <summary>
        /// Source of data
        /// </summary>
        public string DataSource { get; set; }

        /// <summary>
        /// Date of added
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// Date of last edited
        /// </summary>
        public DateTime DateLastEdit { get; set; }

        /// <summary>
        /// username of last edited
        /// </summary>
        public string EditedBy { get; set; }
    }
}
