using Domain.Agreements.CollectiveAgreement;

namespace Persistence.SeedData
{
    internal static class CollectiveAgreementSeedData
    {
        public static CollectiveAgreement CreateRiksAvtalen()
        {
            var riksavtalen = new CollectiveAgreement
            {
                Id = Guid.NewGuid(),
                AgreementName = "Riksavtalen",
                EmployeeOrganization = "Fellesforbundet",
                EmployerOrganization = "NHO Reiseliv",

                Editions = new List<CollectiveAgreementEdition>
                {
                    new CollectiveAgreementEdition
                    {
                        Id = Guid.NewGuid(),
                        ValidFrom = new DateTime(2021, 4, 1),
                        Expired = new DateTime(2022, 1, 31),

                        SalaryTables = new List<SalaryTable> {
                            new SalaryTable
                            {
                                Id= Guid.NewGuid(),
                                ValidFrom = new DateTime(2020, 4, 1),
                                Expired = new DateTime(2021, 3 , 31),

                                SupplementEvening = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "20:00",
                                    End = "00:00",
                                    Rate = 11.52f,
                                },
                                SupplementSaturday = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "14:00",
                                    End = "00:00",
                                    Rate = 11.52f,
                                },
                                SupplementSunday = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "00:00",
                                    End = "00:00",
                                    Rate = 11.52f,
                                },
                                SupplementNight = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "00:00",
                                    End = "06:00",
                                    Rate = 11.52f,
                                },
                                SupplementNightLabour = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "00:00",
                                    End = "06:00",
                                    Rate = 11.52f,
                                },
                            },
                            new SalaryTable
                            {
                                Id= Guid.NewGuid(),
                                ValidFrom = new DateTime(2021, 4, 1),
                                Expired = new DateTime(2022, 3 , 31),

                                SupplementEvening = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "20:00",
                                    End = "00:00",
                                    Rate = 11.52f,
                                },
                                SupplementSaturday = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "14:00",
                                    End = "00:00",
                                    Rate = 11.52f,
                                },
                                SupplementSunday = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "00:00",
                                    End = "00:00",
                                    Rate = 11.52f,
                                },
                                SupplementNight = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "00:00",
                                    End = "06:00",
                                    Rate = 11.52f,
                                },
                                SupplementNightLabour = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "00:00",
                                    End = "06:00",
                                    Rate = 11.52f,
                                },
                            },
                        }

                    },
                    new CollectiveAgreementEdition
                    {
                        Id = Guid.NewGuid(),
                        ValidFrom = new DateTime(2021, 4, 1),

                        SalaryTables = new List<SalaryTable> {
                            new SalaryTable
                            {
                                Id= Guid.NewGuid(),
                                ValidFrom = new DateTime(2022, 4, 1),

                                SupplementEvening = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "20:00",
                                    End = "00:00",
                                    Rate = 11.52f,
                                },
                                SupplementSaturday = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "14:00",
                                    End = "00:00",
                                    Rate = 11.52f,
                                },
                                SupplementSunday = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "00:00",
                                    End = "00:00",
                                    Rate = 11.52f,
                                },
                                SupplementNight = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "00:00",
                                    End = "06:00",
                                    Rate = 11.52f,
                                },
                                SupplementNightLabour = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "00:00",
                                    End = "06:00",
                                    Rate = 11.52f,
                                },
                            },
                        }
                    },

                }

            };

            return riksavtalen; ;
                 
        }
    }
}
