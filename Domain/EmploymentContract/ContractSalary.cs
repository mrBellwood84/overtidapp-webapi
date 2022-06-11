namespace Domain.EmploymentContract
{
    /// <summary>
    /// Data entity for salary as stated in contract
    /// </summary>
    public class ContractSalary
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Salary rate in NOK
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Salary rate valid from
        /// </summary>
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Salary rate expiration date if expired
        /// </summary>
        public DateTime? Expired { get; set; }    
    }
}
