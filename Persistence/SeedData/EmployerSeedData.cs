using Domain.Agreements.CollectiveAgreement;
using Domain.Employment;

namespace Persistence.SeedData
{
    internal static class EmployerSeedData
    {
        public static List<Employer> CreateEmployers(CollectiveAgreement agreement) 
        {
            var employers = new List<Employer> {
                new Employer {
                    Id = Guid.NewGuid(),

                    Name            = "Good Hotel",
                    NameOfficial    = "Good Hotel",
                    Address         = "Good Street 11",
                    AddressOfficial = "Good Street 11",

                    OrganizationNumber = "111.222.333",

                    PostalArea          = "Smallville",
                    PostalAreaOfficial  = "Smallville",

                    ZipCode             = "1202",
                    ZipCodeOfficial     = "1202",

                    County              = "Metropolis",
                    CountyOfficial      = "Metropolis",

                    CollectiveAgreeementId  = agreement.Id,
                    SpecialAgreements       = null,

                    HaveEditRequest = false,

                    DataSource = "System",
                    DateAdded = DateTime.UtcNow,
                    DateLastEdit = DateTime.UtcNow,
                    EditedBy = "System"
                },
                new Employer
                {
                    Id = Guid.NewGuid(),

                    Name            = "Regular Hotel",
                    NameOfficial    = "Regular Hotel",

                    OrganizationNumber = "222.333.444",

                    Address         = "Average Street 12",
                    AddressOfficial = "Average Street 12",

                    PostalArea          = "Smallville",
                    PostalAreaOfficial  = "Smallville",

                    ZipCode         = "1202",
                    ZipCodeOfficial = "1202",

                    County              = "Metropolis",
                    CountyOfficial      = "Metropolis",

                    CollectiveAgreeementId  = agreement.Id,
                    SpecialAgreements       = null,

                    HaveEditRequest = false,

                    DataSource = "System",
                    DateAdded = DateTime.UtcNow,
                    DateLastEdit = DateTime.UtcNow,
                    EditedBy = "System"
                },
                new Employer
                {
                    Id= Guid.NewGuid(),

                    Name            = "Bad Restaurant",
                    NameOfficial    = "Bad Restaurant",

                    OrganizationNumber = "121.212.444",

                    Address         = "Crapstreet 13",
                    AddressOfficial = "Crapstreet 13",

                    PostalArea          = "Smallville",
                    PostalAreaOfficial  = "Smallville",

                    ZipCode         = "1202",
                    ZipCodeOfficial = "1202",

                    County              = "Metropolis",
                    CountyOfficial      = "Metropolis",

                    CollectiveAgreeementId  = null,
                    SpecialAgreements       = null,

                    HaveEditRequest = false,

                    DataSource = "System",
                    DateAdded = DateTime.UtcNow,
                    DateLastEdit = DateTime.UtcNow,
                    EditedBy = "System"
                }
            };

            return employers;
        }
    }
}
