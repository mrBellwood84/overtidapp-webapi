using Domain.Agreements;
using Domain.Agreements.CollectiveAgreement;

namespace Persistence.SeedData
{
    internal static class CollectiveAgreementSeedData
    {
        public static CollectiveAgreementEntity Create()
        {
            var riksavtalen = new CollectiveAgreementEntity
            {
                Id = Guid.NewGuid(),

                Name = "Riksavtalen",

                EmployeeOrganization = "Fellesforbundet",

                EmployerOrganization = "NHO Reiseliv",

                Editions = new List<CollectiveAgreementEdition>
                {
                    new CollectiveAgreementEdition
                    {
                        Id = Guid.NewGuid(),

                        ValidFrom = new DateTime(2020, 4, 1),
                        Expire = new DateTime(2022, 3, 31),

                        MaxHourDefinitions = new List<AgreementRule>
                        {
                            new AgreementRule
                            {
                                Id = Guid.NewGuid(),
                                Limit = 7.5,
                                MaxHourWeek = 37.5,
                                MaxHourMonth = 162.5,
                            },
                            new AgreementRule
                            {
                                Id = Guid.NewGuid(),
                                Limit = 7.08,
                                MaxHourWeek = 35.5,
                                MaxHourMonth = 154,
                            },
                            new AgreementRule
                            {
                                Id = Guid.NewGuid(),
                                Limit = 7,
                                MaxHourWeek = 33.6,
                                MaxHourMonth = 145,
                            }
                        },

                        TimeCalculationRule = new AgreementRule
                        {
                            Id = Guid.NewGuid(),
                            Paragraph = "4.1.1",
                            Reference = new List<ParagraphText>
                            {
                                new ParagraphText
                                {
                                    Id = Guid.NewGuid(),
                                    Text = "Overtid regnes bare for hele og halve timer, således at påbegynt halv time regnes som halv time og overhalv time regnes som hel time.",
                                    Lang = "no",
                                },
                                new ParagraphText
                                {
                                    Id = Guid.NewGuid(),
                                    Text = "Overtime shall be calculated only for full hours and half hours, so that part of a half hour is counted as a half hour and over a half hour is counted as a fullhour.",
                                    Lang = "en",
                                }
                            }
                        },

                        OvertimeRegular = new AgreementRule
                        {
                            Id= Guid.NewGuid(),
                            Rate = 50,
                            Paragraph = "4.1.2",
                            Reference = new List<ParagraphText>
                            {
                                new ParagraphText
                                {
                                    Id = Guid.NewGuid(),
                                    Text = "For overtidstimer betales den individuelle timelønn + 50 %. For overtidsarbeid mellom kl. 21.00 og 06.00 betales et tillegg på 100 %.",
                                    Lang = "no",
                                },
                                new ParagraphText
                                {
                                    Id = Guid.NewGuid(),
                                    Text = "For overtime the employee shall receive his/her hourly pay + 50 %. For overtime work between 21.00 and 06.00 the supplement shall be 100%.",
                                    Lang = "en",
                                }
                            }
                        },

                        OvertimeNight = new AgreementRule
                        {
                            Id= Guid.NewGuid(),
                            Rate = 100,
                            Paragraph = "4.1.2",
                            Reference = new List<ParagraphText>
                            {
                                new ParagraphText
                                {
                                    Id = Guid.NewGuid(),
                                    Text = "For overtidstimer betales den individuelle timelønn + 50 %. For overtidsarbeid mellom kl. 21.00 og 06.00 betales et tillegg på 100 %.",
                                    Lang = "no",
                                },
                                new ParagraphText
                                {
                                    Id = Guid.NewGuid(),
                                    Text = "For overtime the employee shall receive his/her hourly pay + 50 %. For overtime work between 21.00 and 06.00 the supplement shall be 100%.",
                                    Lang = "en",
                                }
                            }
                        },

                        OvertimeDayOff = new AgreementRule
                        {
                            Id= Guid.NewGuid(),
                            Rate = 100,
                            Paragraph = "4.1.3",
                            Reference = new List<ParagraphText>
                            {
                                new ParagraphText
                                {
                                    Id = Guid.NewGuid(),
                                    Text = "For arbeid på ordinære fridager betales: Individuell timelønn + 100 % x antall arbeidede timer",
                                    Lang = "no",
                                },
                                new ParagraphText
                                {
                                    Id = Guid.NewGuid(),
                                    Text = "For work on ordinary days off the employee shall receive: Individual hourly pay + 100 % x number of hours worked.",
                                    Lang = "en",
                                }
                            }
                        },

                        OvertimeDayoffPartTime = new AgreementRule
                        {
                            Id= Guid.NewGuid(),
                            Rate = 100,
                            Paragraph = "4.1.7",
                            Reference = new List<ParagraphText>
                            {
                                new ParagraphText
                                {
                                    Id = Guid.NewGuid(),
                                    Text = "Deltidsansatte skal betales 100 % tillegg på fridager avmerket på vaktliste, jfr. § 2 pkt. 5 siste setning. For arbeid på dager som ikke er markert med fridager, vil overtidsbetaling ikke komme til anvendelse med mindre arbeidstakeren arbeider mer enn 35,5 timer pr. uke, eventuelt 7 timer og 5 minutter pr. dag.",
                                    Lang = "no",
                                },
                                new ParagraphText
                                {
                                    Id = Guid.NewGuid(),
                                    Text = "Overtime pay for part-time employees shall be 100% on days off that are recorded on the roster, see § 2, subsection 5, last sentence. For days that are not marked as days off, overtime pay will not apply unless the employee works a week of more than 35.5hours or 7 hours and 5 minutes per day.",
                                    Lang = "en",
                                }
                            }
                        },

                        WageSupplementTable = new List<WageSupplementTable>
                        {
                            new WageSupplementTable
                            {
                                Id = Guid.NewGuid(),

                                ValidFrom = new DateTime(2020, 4, 1),
                                Expire = new DateTime(2021, 3, 31),

                                SupplementEvening = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "21:00",
                                    End = "00:00",
                                    Rate = 12.81,
                                },

                                SupplementSaturday = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "14.00",
                                    End = "00:00",
                                    Rate = 24.34,

                                },

                                SupplementSunday = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "06:00",
                                    End = "00:00",
                                    Rate = 24.34
                                },

                                SupplementNight = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "00:00",
                                    End = "06:00",
                                    Rate = 25.62,
                                },

                                SupplementNightLabour = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "00:00",
                                    End = "06:00",
                                    Rate = 44.82,
                                }
                            },

                            new WageSupplementTable
                            {
                                Id = Guid.NewGuid(),

                                ValidFrom = new DateTime(2021, 4, 1),
                                Expire = new DateTime(2022, 3, 31),

                                SupplementEvening = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "21:00",
                                    End = "00:00",
                                    Rate = 13.13,
                                },

                                SupplementSaturday = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "14.00",
                                    End = "00:00",
                                    Rate = 24.95,

                                },

                                SupplementSunday = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "06:00",
                                    End = "00:00",
                                    Rate = 24.95
                                },

                                SupplementNight = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "00:00",
                                    End = "06:00",
                                    Rate = 26.26
                                },

                                SupplementNightLabour = new WageSupplement
                                {
                                    Id = Guid.NewGuid(),
                                    Start = "00:00",
                                    End = "06:00",
                                    Rate = 45.94,
                                }
                            }
                        }

                    },

                }
            };

            return riksavtalen;
                 
        }
    }
}
