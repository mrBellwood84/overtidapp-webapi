using Domain.Agreements.CollectiveAgreement;
using Domain.Employer;

namespace Persistence.SeedData
{
    internal static class EmployerSeedData
    {
        public static List<EmployerEntity> CreateEmployers(CollectiveAgreementEntity agreement) 
        {
            var employers = new List<EmployerEntity> {
                new EmployerEntity {

                    Id = Guid.NewGuid(),

                    NameLegal       = "Good Hotel",
                    NameUsed        = "Good Hotel",
                    AddressLegal    = "Good Street 11",
                    AddressUsed     = "Good Street 11",

                    OrganizationNumber = "111.222.333",

                    PostAreaLegal   = "Smallville",
                    PostAreaUsed    = "Smallville",

                    ZipCodeLegal    = "1202",
                    ZipCodeUsed     = "1202",

                    RegionLegal     = "Metropolis",
                    RegionUsed      = "Metropolis",

                    CollectiveAgreementId  = agreement.Id,

                    HasChangeRequest = false,

                    DateAdded       = DateTime.UtcNow,
                    AddedBy         = "System",
                    DateLastUpdate  = DateTime.UtcNow,
                    LastUpdateBy    = "System"
                },
                new EmployerEntity {

                    Id = Guid.NewGuid(),

                    NameLegal       = "Regular Hotel",
                    NameUsed        = "Regular Hotel",
                    AddressLegal    = "Mainstreet 11",
                    AddressUsed     = "Maintreet 11",

                    OrganizationNumber = "222.111.333",

                    PostAreaLegal   = "Smallville",
                    PostAreaUsed    = "Smallville",

                    ZipCodeLegal    = "1202",
                    ZipCodeUsed     = "1202",

                    RegionLegal     = "Metropolis",
                    RegionUsed      = "Metropolis",

                    CollectiveAgreementId  = agreement.Id,

                    HasChangeRequest = false,

                    DateAdded       = DateTime.UtcNow,
                    AddedBy         = "System",
                    DateLastUpdate  = DateTime.UtcNow,
                    LastUpdateBy    = "System"
                },
                new EmployerEntity {

                    Id = Guid.NewGuid(),

                    NameLegal       = "Shitty Hotel",
                    NameUsed        = "Shitty Hotel",
                    AddressLegal    = "Shitstreet 11",
                    AddressUsed     = "Shitstreet 11",

                    OrganizationNumber = "222.333.111",

                    PostAreaLegal   = "Smallville",
                    PostAreaUsed    = "Smallville",

                    ZipCodeLegal    = "1202",
                    ZipCodeUsed     = "1202",

                    RegionLegal     = "Metropolis",
                    RegionUsed      = "Metropolis",

                    CollectiveAgreementId  = null,

                    HasChangeRequest = false,

                    DateAdded       = DateTime.UtcNow,
                    AddedBy         = "System",
                    DateLastUpdate  = DateTime.UtcNow,
                    LastUpdateBy    = "System"
                },
            };

            return employers;
        }
    }
}
