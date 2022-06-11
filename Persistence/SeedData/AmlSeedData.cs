using Domain.Agreements;
using Domain.Agreements.Aml;

namespace Persistence.SeedData
{
    public class AmlSeedData
    {
        public static AmlEntity Create()
        {
            var data = new AmlEntity
            {
                Id = Guid.NewGuid(),

                WorkhoursDay = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 9,
                    Paragraph = "10-4 (1)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Den alminnelige arbeidstid må ikke overstige ni timer i løpet av 24 timer og 40 timer i løpet av sju dager.",
                            Lang = "no"
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = " Normal working hours must not exceed nine hours per 24 hours and 40 hours per seven days.",
                            Lang = "en"
                        }
                    }
                },

                WorkhoursDayMaxLegal = new AgreementRule
                {
                    Id= Guid.NewGuid(),
                    Limit= 13,
                    Paragraph = "10-6 (8)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Samlet arbeidstid må ikke overstige 13 timer i løpet av 24 timer eller 48 timer i løpet av sju dager. Grensen på 48 timer i løpet av sju dager kan gjennomsnittsberegnes over en periode på åtte uker, likevel slik at den samlede arbeidstiden etter § 10-5 andre ledd og § 10-6 femte ledd ikke overstiger 69 timer i noen enkelt uke.",
                            Lang= "no"
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Total working hours must not exceed 13 hours per 24 hours or 48 hours per seven days. The limit of 48 hours per seven days may be calculated according to a fixed average over a period of eight weeks, provided that the total working hours pursuant to section 10-5, second paragraph, and section 10-6, fifth paragraph, do not exceed 69 hours in any one week.",
                            Lang = "en",
                        }
                    }
                },

                WorkhoursDayIndividual = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 10,
                    Paragraph = "10-5 (1)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Arbeidsgiver og arbeidstaker kan skriftlig avtale at den alminnelige arbeidstid kan ordnes slik at den i løpet av en periode på høyst 52 uker i gjennomsnitt ikke blir lenger enn foreskrevet i § 10-4, men slik at den alminnelige arbeidstiden ikke overstiger ti timer i løpet av 24 timer og 48 timer i løpet av sju dager. Grensen på 48 timer i løpet av sju dager kan gjennomsnittsberegnes over en periode på åtte uker, likevel slik at den alminnelige arbeidstiden ikke overstiger 50 timer i noen enkelt uke. Avtale etter dette ledd kan ikke inngås med arbeidstaker som er midlertidig ansatt med grunnlag i § 14-9 andre ledd bokstav f.",
                            Lang = "no",
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "The employer and the employee may in writing agree that normal working hours may be arranged in such a way that, on average, during a period not exceeding 52 weeks, they are no longer than prescribed by section 10-4, but that the total working hours do not exceed ten hours per 24 hours and 48 hours per seven days. The limit of 48 hours per seven days may be calculated on the basis of a fixed average over a period of eight weeks provided that normal working hours do not exceed 50 hours in any one week. Pursuant to the present paragraph, an agreement may not be entered into with an employee temporarily employed in accordance with section 14-9, second paragraph (f).",
                            Lang = "en",
                        }
                    }
                },

                WorkhoursDaySpecial = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 12.5,
                    Paragraph = "10-5 (2)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Arbeidsgiver og arbeidstakernes tillitsvalgte i virksomhet som er bundet av tariffavtale, kan skriftlig avtale at den alminnelige arbeidstiden skal ordnes slik at den i løpet av en periode på høyst 52 uker i gjennomsnitt ikke blir lenger enn foreskrevet i § 10-4, men slik at den alminnelige arbeidstiden ikke overstiger 12,5 timer i løpet av 24 timer og 48 timer i løpet av sju dager. Grensen på 48 timer i løpet av sju dager kan gjennomsnittsberegnes over en periode på åtte uker, likevel slik at den alminnelige arbeidstiden ikke overstiger 54 timer i noen enkelt uke. Ved inngåelse av avtale som innebærer at den alminnelige arbeidstiden overstiger 10 timer i løpet av 24 timer, skal det legges særlig vekt på hensynet til arbeidstakernes helse og velferd.",
                            Lang = "no",
                        },
                        new ParagraphText
                        {
                            Id= Guid.NewGuid(),
                            Text = "The employer and the employees' elected representatives in undertakings bound by a collective pay agreement may in writing agree that normal working hours shall be arranged in such a way that on average, during a period not exceeding 52 weeks, they are no longer than prescribed by section 10-4, but that the normal working hours do not exceed twelve and one-half hours per 24 hours and 48 hours per seven days. The limit of 48 hours per seven days may be calculated according to a fixed average over a period of eight weeks provided, however, that normal working hours do not exceed 54 hours in any one week. When entering into an agreement involving normal working hours exceeding 10 hours per 24 hours, particular regard shall be paid to the employees' health and welfare.",
                            Lang = "en",
                        }
                    }
                },

                WorkhoursDaySpecialMaxLegal = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 16,
                    Paragraph = "10-6 (9)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Arbeidsgiver og arbeidstakernes tillitsvalgte i virksomhet som er bundet av tariffavtale, kan skriftlig avtale unntak fra grensen på 13 timer i åttende ledd, men slik at den samlede arbeidstid ikke overstiger 16 timer i løpet av 24 timer. Arbeidstaker skal i så fall sikres tilsvarende kompenserende hvileperioder eller, der dette ikke er mulig, annet passende vern.",
                            Lang = "no",
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "The employer and the employees' elected representatives in undertakings bound by a collective pay agreement may agree in writing to exceptions from the limit of 13 hours provided in the eighth paragraph provided, however, that the total working hours do not exceed 16 hours per 24 hours. The employee shall in such case be ensured corresponding compensatory rest periods or, where this is not possible, other appropriate protection.",
                            Lang = "en",
                        }
                    }
                },

                WorkhoursWeek = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 40,
                    Paragraph = "10-4 (1)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Den alminnelige arbeidstid må ikke overstige ni timer i løpet av 24 timer og 40 timer i løpet av sju dager.",
                            Lang = "no"
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = " Normal working hours must not exceed nine hours per 24 hours and 40 hours per seven days.",
                            Lang = "en"
                        }
                    }
                },

                WorkhoursWeekShift = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 38,
                    Paragraph = "10-4 (4)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id= Guid.NewGuid(),
                            Text = "Den alminnelige arbeidstid må ikke overstige ni timer i løpet av 24 timer og 38 timer i løpet av sju dager for: a. døgnkontinuerlig skiftarbeid og sammenlignbart turnusarbeid, b.  arbeid på to skift som regelmessig drives på søn- og helgedager, og sammenlignbart turnusarbeid som regelmessig drives på søn- og helgedager, c.  arbeid som innebærer at den enkelte arbeidstaker må arbeide minst hver tredje søndag, d.  arbeid som hovedsakelig drives om natten.",
                            Lang = "no",
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Normal working hours must not exceed nine hours per 24 hours and 38 hours per seven days for, a. semi-continuous shift work and comparable rota work, b.	work on two shifts which are regularly carried out on Sundays and public holidays and comparable rota work regularly carried out on Sundays and public holidays, c	work which necessitates that individual employees work at least every third Sunday, d.	work principally performed at night."
                        }
                    }
                },

                WorkhoursWeekIndividual = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 50,
                    Paragraph = "10-5 (1)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Arbeidsgiver og arbeidstaker kan skriftlig avtale at den alminnelige arbeidstid kan ordnes slik at den i løpet av en periode på høyst 52 uker i gjennomsnitt ikke blir lenger enn foreskrevet i § 10-4, men slik at den alminnelige arbeidstiden ikke overstiger ti timer i løpet av 24 timer og 48 timer i løpet av sju dager. Grensen på 48 timer i løpet av sju dager kan gjennomsnittsberegnes over en periode på åtte uker, likevel slik at den alminnelige arbeidstiden ikke overstiger 50 timer i noen enkelt uke. Avtale etter dette ledd kan ikke inngås med arbeidstaker som er midlertidig ansatt med grunnlag i § 14-9 andre ledd bokstav f.",
                            Lang = "no",
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "The employer and the employee may in writing agree that normal working hours may be arranged in such a way that, on average, during a period not exceeding 52 weeks, they are no longer than prescribed by section 10-4, but that the total working hours do not exceed ten hours per 24 hours and 48 hours per seven days. The limit of 48 hours per seven days may be calculated on the basis of a fixed average over a period of eight weeks provided that normal working hours do not exceed 50 hours in any one week. Pursuant to the present paragraph, an agreement may not be entered into with an employee temporarily employed in accordance with section 14-9, second paragraph (f).",
                            Lang = "en",
                        }
                    }
                },

                WorkhoursWeekSpecial = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 54,
                    Paragraph = "10-5 (2)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Arbeidsgiver og arbeidstakernes tillitsvalgte i virksomhet som er bundet av tariffavtale, kan skriftlig avtale at den alminnelige arbeidstiden skal ordnes slik at den i løpet av en periode på høyst 52 uker i gjennomsnitt ikke blir lenger enn foreskrevet i § 10-4, men slik at den alminnelige arbeidstiden ikke overstiger 12,5 timer i løpet av 24 timer og 48 timer i løpet av sju dager. Grensen på 48 timer i løpet av sju dager kan gjennomsnittsberegnes over en periode på åtte uker, likevel slik at den alminnelige arbeidstiden ikke overstiger 54 timer i noen enkelt uke. Ved inngåelse av avtale som innebærer at den alminnelige arbeidstiden overstiger 10 timer i løpet av 24 timer, skal det legges særlig vekt på hensynet til arbeidstakernes helse og velferd.",
                            Lang = "no",
                        },
                        new ParagraphText
                        {
                            Id= Guid.NewGuid(),
                            Text = "The employer and the employees' elected representatives in undertakings bound by a collective pay agreement may in writing agree that normal working hours shall be arranged in such a way that on average, during a period not exceeding 52 weeks, they are no longer than prescribed by section 10-4, but that the normal working hours do not exceed twelve and one-half hours per 24 hours and 48 hours per seven days. The limit of 48 hours per seven days may be calculated according to a fixed average over a period of eight weeks provided, however, that normal working hours do not exceed 54 hours in any one week. When entering into an agreement involving normal working hours exceeding 10 hours per 24 hours, particular regard shall be paid to the employees' health and welfare.",
                            Lang = "en",
                        }
                    }
                },

                WorkhoursWeekAverage = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 48,
                    Period = 8,
                    Paragraph = "10-6 (8)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Samlet arbeidstid må ikke overstige 13 timer i løpet av 24 timer eller 48 timer i løpet av sju dager. Grensen på 48 timer i løpet av sju dager kan gjennomsnittsberegnes over en periode på åtte uker, likevel slik at den samlede arbeidstiden etter § 10-5 andre ledd og § 10-6 femte ledd ikke overstiger 69 timer i noen enkelt uke.",
                            Lang= "no"
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Total working hours must not exceed 13 hours per 24 hours or 48 hours per seven days. The limit of 48 hours per seven days may be calculated according to a fixed average over a period of eight weeks, provided that the total working hours pursuant to section 10-5, second paragraph, and section 10-6, fifth paragraph, do not exceed 69 hours in any one week.",
                            Lang = "en",
                        }
                    }
                },

                WorkhoursWeekMaxLegal = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 69,
                    Paragraph = "10-6 (8)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Samlet arbeidstid må ikke overstige 13 timer i løpet av 24 timer eller 48 timer i løpet av sju dager. Grensen på 48 timer i løpet av sju dager kan gjennomsnittsberegnes over en periode på åtte uker, likevel slik at den samlede arbeidstiden etter § 10-5 andre ledd og § 10-6 femte ledd ikke overstiger 69 timer i noen enkelt uke.",
                            Lang= "no"
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Total working hours must not exceed 13 hours per 24 hours or 48 hours per seven days. The limit of 48 hours per seven days may be calculated according to a fixed average over a period of eight weeks, provided that the total working hours pursuant to section 10-5, second paragraph, and section 10-6, fifth paragraph, do not exceed 69 hours in any one week.",
                            Lang = "en",
                        }
                    }
                },

                MaxOvertimeWeek = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 10,
                    Paragraph = "10-6 (4)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Overtidsarbeidet må ikke overstige ti timer i løpet av sju dager, 25 timer i fire sammenhengende uker og 200 timer innenfor en periode på 52 uker.",
                            Lang = "no",
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Overtime work must not exceed ten hours per seven days, 25 hours per four consecutive weeks or 200 hours during a period of 52 weeks.",
                            Lang = "en",
                        }
                    },
                },

                MaxOvertimeWeekSpecial = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 20,
                    Paragraph = "10-6 (5)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Arbeidsgiver og arbeidstakernes tillitsvalgte i virksomhet som er bundet av tariffavtale, kan skriftlig avtale overtidsarbeid inntil 20 timer i løpet av sju dager, men slik at samlet overtidsarbeid ikke overstiger 50 timer i fire sammenhengende uker. Overtidsarbeidet må ikke overstige 300 timer innenfor en periode på 52 uker.",
                            Lang = "no"
                        },
                        new ParagraphText
                        {
                            Id= Guid.NewGuid(),
                            Text = "The employer and the employees' elected representatives in undertakings bound by a collective pay agreement may agree in writing upon overtime work not exceeding 20 hours per seven days, but that total overtime work does not exceed 50 hours per four consecutive weeks. Overtime work must not exceed 300 hours during a period of 52 weeks.",
                            Lang = "en"
                        }
                    }
                },

                MaxOvertimeMonth = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 25,
                    Period = 4,
                    Paragraph = "10-6 (4)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Overtidsarbeidet må ikke overstige ti timer i løpet av sju dager, 25 timer i fire sammenhengende uker og 200 timer innenfor en periode på 52 uker.",
                            Lang = "no",
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Overtime work must not exceed ten hours per seven days, 25 hours per four consecutive weeks or 200 hours during a period of 52 weeks.",
                            Lang = "en",
                        }
                    },
                },

                MaxOvertimeMonthSpecial = new AgreementRule
                {
                    Id = new Guid(),
                    Limit = 50,
                    Period = 4,
                    Paragraph = "10-6 (5)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Arbeidsgiver og arbeidstakernes tillitsvalgte i virksomhet som er bundet av tariffavtale, kan skriftlig avtale overtidsarbeid inntil 20 timer i løpet av sju dager, men slik at samlet overtidsarbeid ikke overstiger 50 timer i fire sammenhengende uker. Overtidsarbeidet må ikke overstige 300 timer innenfor en periode på 52 uker.",
                            Lang = "no"
                        },
                        new ParagraphText
                        {
                            Id= Guid.NewGuid(),
                            Text = "The employer and the employees' elected representatives in undertakings bound by a collective pay agreement may agree in writing upon overtime work not exceeding 20 hours per seven days, but that total overtime work does not exceed 50 hours per four consecutive weeks. Overtime work must not exceed 300 hours during a period of 52 weeks.",
                            Lang = "en"
                        }
                    }
                },

                MaxOvertimeYear = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 200,
                    Paragraph = "10-6 (4)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Overtidsarbeidet må ikke overstige ti timer i løpet av sju dager, 25 timer i fire sammenhengende uker og 200 timer innenfor en periode på 52 uker.",
                            Lang = "no",
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Overtime work must not exceed ten hours per seven days, 25 hours per four consecutive weeks or 200 hours during a period of 52 weeks.",
                            Lang = "en",
                        }
                    },
                },

                MaxOvertimeYearSpecial = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 300,
                    Paragraph = "10-6 (5)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Arbeidsgiver og arbeidstakernes tillitsvalgte i virksomhet som er bundet av tariffavtale, kan skriftlig avtale overtidsarbeid inntil 20 timer i løpet av sju dager, men slik at samlet overtidsarbeid ikke overstiger 50 timer i fire sammenhengende uker. Overtidsarbeidet må ikke overstige 300 timer innenfor en periode på 52 uker.",
                            Lang = "no"
                        },
                        new ParagraphText
                        {
                            Id= Guid.NewGuid(),
                            Text = "The employer and the employees' elected representatives in undertakings bound by a collective pay agreement may agree in writing upon overtime work not exceeding 20 hours per seven days, but that total overtime work does not exceed 50 hours per four consecutive weeks. Overtime work must not exceed 300 hours during a period of 52 weeks.",
                            Lang = "en"
                        }
                    }
                },

                WorkfreeDay = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 11,
                    Paragraph = "10-8 (1)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = " Arbeidstaker skal ha minst 11 timer sammenhengende arbeidsfri i løpet av 24 timer. Den arbeidsfrie perioden skal plasseres mellom to hovedarbeidsperioder.",
                            Lang = "no",
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "An employee shall have at least 11 hours continuous off-duty time per 24 hours. The off-duty period shall be placed between two main work periods.",
                            Lang= "en"
                        }
                    }
                },

                WorkfreeDaySpecial = new AgreementRule
                {
                    Id= Guid.NewGuid(),
                    Limit = 8,
                    Paragraph = "10-8 (3)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Arbeidsgiver og arbeidstakernes tillitsvalgte i virksomhet som er bundet av tariffavtale, kan skriftlig avtale unntak fra bestemmelsene i første og andre ledd. Slik avtale kan bare inngås dersom arbeidstaker sikres tilsvarende kompenserende hvileperioder eller, der dette ikke er mulig, annet passende vern. Det kan ikke avtales kortere arbeidsfri periode enn 8 timer i løpet av 24 timer eller 28 timer i løpet av sju dager. Grensen på 8 timer gjelder ikke når arbeid utover avtalt arbeidstid (jf. § 10-6 første ledd) eller arbeid ved utkalling under beredskapsvakt utenfor arbeidsstedet er nødvendig for å unngå alvorlige driftsforstyrrelser. Ved virksomhet som ikke er bundet av tariffavtale, kan arbeidsgiver og arbeidstakernes representanter på samme vilkår skriftlig avtale arbeid i den arbeidsfrie perioden, når dette er nødvendig for å unngå alvorlige driftsforstyrrelser.",
                            Lang = "no",
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "The employer and the employees' elected representatives in undertakings bound by a collective pay agreement, may agree in writing upon exceptions from the provisions of the first and second paragraph. Such an agreement may only be entered into if the employee is ensured corresponding compensatory rest periods or, where this is not possible, other appropriate protection. Off-duty periods shorter than 8 hours per 24 hours or 28 hours per seven days may not be agreed. The limit of 8 hours shall not apply when work in excess of agreed working hours (cf. section 10- 6, first paragraph)or work in connection with call-out during standby duty outside the workplace is necessary in order to avoid serious disturbances to operations. At undertakings which are not bound by a collective pay agreement, the employer and the employees' representatives may conclude a written agreement on the same terms to the effect that overtime may be worked during the off-duty period when this is necessary in order to avoid serious disturbances to operations.",
                            Lang = "en",
                        }
                    }
                },

                WorkfreeWeek = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 35,
                    Period = 7,
                    Paragraph = "10-8 (2)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Arbeidstaker skal ha en sammenhengende arbeidsfri periode på 35 timer i løpet av sju dager.",
                            Lang = "no",
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "An employee shall have a continuous off-duty period of 35 hours per seven days.",
                            Lang = "en"
                        }
                    }
                },

                WorkfreeWeekSpecial = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Limit = 28,
                    Period = 7,
                    Paragraph = "10-8 (3)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Arbeidsgiver og arbeidstakernes tillitsvalgte i virksomhet som er bundet av tariffavtale, kan skriftlig avtale unntak fra bestemmelsene i første og andre ledd. Slik avtale kan bare inngås dersom arbeidstaker sikres tilsvarende kompenserende hvileperioder eller, der dette ikke er mulig, annet passende vern. Det kan ikke avtales kortere arbeidsfri periode enn 8 timer i løpet av 24 timer eller 28 timer i løpet av sju dager. Grensen på 8 timer gjelder ikke når arbeid utover avtalt arbeidstid (jf. § 10-6 første ledd) eller arbeid ved utkalling under beredskapsvakt utenfor arbeidsstedet er nødvendig for å unngå alvorlige driftsforstyrrelser. Ved virksomhet som ikke er bundet av tariffavtale, kan arbeidsgiver og arbeidstakernes representanter på samme vilkår skriftlig avtale arbeid i den arbeidsfrie perioden, når dette er nødvendig for å unngå alvorlige driftsforstyrrelser.",
                            Lang = "no",
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "The employer and the employees' elected representatives in undertakings bound by a collective pay agreement, may agree in writing upon exceptions from the provisions of the first and second paragraph. Such an agreement may only be entered into if the employee is ensured corresponding compensatory rest periods or, where this is not possible, other appropriate protection. Off-duty periods shorter than 8 hours per 24 hours or 28 hours per seven days may not be agreed. The limit of 8 hours shall not apply when work in excess of agreed working hours (cf. section 10- 6, first paragraph)or work in connection with call-out during standby duty outside the workplace is necessary in order to avoid serious disturbances to operations. At undertakings which are not bound by a collective pay agreement, the employer and the employees' representatives may conclude a written agreement on the same terms to the effect that overtime may be worked during the off-duty period when this is necessary in order to avoid serious disturbances to operations.",
                            Lang = "en",
                        }
                    }
                },

                OvertimeDefinition = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Paragraph = "10-6 (2)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id= Guid.NewGuid(),
                            Text = "Varer arbeidet for noen arbeidstaker ut over lovens grense for den alminnelige arbeidstid regnes det overskytende som overtidsarbeid.",
                            Lang = "no",
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "If in the case of some employees the work exceeds the limit prescribed by the Act for normal working hours, the time in excess is regarded as overtime.",
                            Lang = "en",
                        }
                    }
                },

                SupplementRate = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Rate = 40,
                    Paragraph = "10-6 (11)",
                    Reference= new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "For overtidsarbeid skal det betales et tillegg til den lønn arbeidstakeren har for tilsvarende arbeid i den alminnelige arbeidstiden. Tillegget skal være minst 40 prosent.",
                            Lang = "no",
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "For overtime work a supplement shall be paid in addition to the pay received by the employee for corresponding work during normal working hours. The overtime supplement shall be at least 40 per cent.",
                            Lang = "en",
                        }
                    }
                },

                SundayOff = new AgreementRule
                {
                    Id = Guid.NewGuid(),
                    Paragraph = "10-8 (4)",
                    Reference = new List<ParagraphText>
                    {
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Arbeidsfri som nevnt i andre ledd skal så vidt mulig omfatte søndag. Arbeidstaker som har utført søn- og helgedagsarbeid, skal ha arbeidsfri følgende søn- og helgedagsdøgn. Arbeidsgiver og arbeidstaker kan skriftlig avtale en arbeidstidsordning som i gjennomsnitt gir arbeidstaker arbeidsfri annenhver søn- og helgedag over en periode på 26 uker, likevel slik at det ukentlige fridøgn minst hver fjerde uke faller på en søn- eller helgedag.",
                            Lang= "no",
                        },
                        new ParagraphText
                        {
                            Id = Guid.NewGuid(),
                            Text = "Off-duty time as referred to in the second paragraph shall as far as possible include Sundays. An employee who has worked on a Sunday or public holiday shall be off duty on the following Sunday or public holiday. The employer and the employee may agree in writing to a working-hour arrangement that ensures that the employees will be off duty on average every other Sunday and public holiday over a period of 26 weeks, provided, however, that the weekly 24-hour off-duty period falls on a Sunday or public holiday at least every fourth week.",
                            Lang = "en",
                        }
                    }
                }
            };


            return data;
        }
    }
}
