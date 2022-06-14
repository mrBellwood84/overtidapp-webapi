namespace Domain.Agreements.CollectiveAgreement
{
    public class CollectiveAgreementEdition
    {
        /// <summary>
        /// Entity Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Date valid from
        /// </summary>
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Date of expiration when expired
        /// </summary>
        public DateTime Expire { get; set; }

        /// <summary>
        /// List of agreement rules deciding max hour limits for contract
        /// </summary>
        public List<AgreementRule> MaxHourDefinitions { get; set; }


        /// <summary>
        /// Paragraph only, 
        /// rule for calculating overtime every started half hour
        /// </summary>
        public AgreementRule TimeCalculationRule { get; set; }

        public AgreementRule OvertimeRegular { get; set; }
        
        public AgreementRule OvertimeNight { get; set; }

        public AgreementRule OvertimeDayOff { get; set; }

        public AgreementRule OvertimeDayoffPartTime { get; set; }


        /// <summary>
        /// Salary table for minimum wage and wage supplements,
        /// usually change every year
        /// </summary>
        public List<WageSupplementTable> WageSupplementTable { get; set; }
    }
}
