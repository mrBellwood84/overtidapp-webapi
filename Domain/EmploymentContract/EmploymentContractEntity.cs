namespace Domain.EmploymentContract
{
    /// <summary>
    /// Entity model for employment contract-
    /// </summary>
    public class EmploymentContractEntity
    {
        /// <summary>
        /// Entity Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// User name (from identity)
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Entity id of employer
        /// </summary>
        public Guid EmployerId { get; set; }

        /// <summary>
        /// Basic jobtitle
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Start of employment contract
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Expiration date of employment contract
        /// </summary>
        public DateTime? DateExpire { get; set; }

        /// <summary>
        /// Date of ended employment contract
        /// </summary>
        public DateTime? DateEnded { get; set; }

        /// <summary>
        /// Max hours per month as defined by agreement or aml
        /// </summary>
        public int MaxHourMonth { get; set; }

        /// <summary>
        /// Level of employment / position percentage
        /// </summary>
        public double PositionPercent { get; set; }

        /// <summary>
        /// True if employment is permanent
        /// </summary>
        public bool PermanentEmployment { get; set; }

        /// <summary>
        /// Minutes of unpaid break during a shift
        /// </summary>
        public int UnpaidBreak { get; set; }

        /// <summary>
        /// True if contract include working weekends
        /// </summary>
        public bool IncludeWeekends { get; set; }

        /// <summary>
        /// Id of currently valid collective agreement
        /// </summary>
        public Guid? CollectiveAgreementId { get; set; }

        /// <summary>
        /// List of salary entities
        /// </summary>
        public List<ContractSalary> Salary { get; set; }
    }
}
