namespace Domain.Agreements.Aml
{
    /// <summary>
    /// Model for rules in the nowegian working environment act.
    /// Model used for ruleset for calculating overtime 
    /// and creating special agreements in frontend application.
    /// </summary>
    public class AmlEntity
    {
        /// <summary>
        /// Guid id for database primary key
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Hour limit for normal workday before overtime.
        /// </summary>
        public AgreementRule WorkhoursDay { get; set; }
        /// <summary>
        /// Max legal working hours per day
        /// </summary>
        public AgreementRule WorkhoursDayMaxLegal { get; set; }
        /// <summary>
        /// Limit for normal working day with individual written agreement
        /// </summary>
        public AgreementRule WorkhoursDayIndividual { get; set; }


        /// <summary>
        /// Limit for normal workday with with special agreement
        /// </summary>
        public AgreementRule WorkhoursDaySpecial { get; set; }
        /// <summary>
        /// Max legal working hours with special agreement
        /// </summary>
        public AgreementRule WorkhoursDaySpecialMaxLegal { get; set; }


        /// <summary>
        /// Limit for workhours per week normal
        /// </summary>
        public AgreementRule WorkhoursWeek { get; set; }
        /// <summary>
        /// Limit for workhours per week for shift work
        /// </summary>
        public AgreementRule WorkhoursWeekShift { get; set; }
        /// <summary>
        /// Limit for workhours per week with individual agreement
        /// </summary>
        public AgreementRule WorkhoursWeekIndividual { get; set; }
        /// <summary>
        /// Limit for workhours per week with individual agreement
        /// </summary>
        public AgreementRule WorkhoursWeekSpecial { get; set; }


        /// <summary>
        /// Limits legal average over a timespan of 8 weeks
        /// </summary>
        public AgreementRule WorkhoursWeekAverage { get; set; }
        /// <summary>
        /// Max legal overtime over 7 days
        /// </summary>
        public AgreementRule WorkhoursWeekMaxLegal { get; set; }


        /// <summary>
        /// Max legal overtime per week
        /// </summary>
        public AgreementRule MaxOvertimeWeek { get; set; }
        /// <summary>
        /// Max legal overtime per week with special agreement
        /// </summary>
        public AgreementRule MaxOvertimeWeekSpecial { get; set; }


        /// <summary>
        /// Max legal overtime over a 4 week period
        /// </summary>
        public AgreementRule MaxOvertimeMonth { get; set; }
        /// <summary>
        /// Max legal opvertime over a 4 week period with special agreement
        /// </summary>
        public AgreementRule MaxOvertimeMonthSpecial { get; set; }


        /// <summary>
        /// Max Legal overtime per year
        /// </summary>
        public AgreementRule MaxOvertimeYear { get; set; }
        /// <summary>
        /// Max legal overtime per year with special agreement
        /// </summary>
        public AgreementRule MaxOvertimeYearSpecial { get; set; }


        /// <summary>
        /// Limit for minimum hours between shifts
        /// </summary>
        public AgreementRule WorkfreeDay { get; set; }
        /// <summary>
        /// Limit for minimum hours between shift with special agreement
        /// </summary>
        public AgreementRule WorkfreeDaySpecial { get; set; }


        /// <summary>
        /// Limit for minimum weekly work free hours
        /// </summary>
        public AgreementRule WorkfreeWeek { get; set; }
        /// <summary>
        /// Limit for minimum weekly workfree hours with special agreement
        /// </summary>
        public AgreementRule WorkfreeWeekSpecial { get; set; }


        /// <summary>
        /// Definition of overtime by law, law reference only
        /// </summary>
        public AgreementRule OvertimeDefinition { get; set; }
        /// <summary>
        /// Duty to pay overtime supplement, law reference only
        /// </summary>
        public AgreementRule SupplementRate { get; set; }
        /// <summary>
        /// Duty to sunday off, reference and overtime supplement percent
        /// </summary>
        public AgreementRule SundayOff { get; set; }
    }
}