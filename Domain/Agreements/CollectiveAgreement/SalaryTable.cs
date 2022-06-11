namespace Domain.Agreements.CollectiveAgreement
{
    public class SalaryTable
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Salary table valid from this date
        /// </summary>
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Date for salary expiration, null if not expired
        /// </summary>
        public DateTime Expire { get; set; }


        /// <summary>
        /// Wage supplement for evening shifts
        /// </summary>
        public WageSupplement SupplementEvening { get; set; }

        /// <summary>
        /// Wage supplement for saturday shifts
        /// </summary>
        public WageSupplement SupplementSaturday { get; set; }

        /// <summary>
        /// Wage supplement for sunday shifts
        /// </summary>
        public WageSupplement SupplementSunday { get; set; }

        /// <summary>
        /// Wage supplement for night shifts with no labour
        /// </summary>
        public WageSupplement SupplementNight { get; set; }

        /// <summary>
        /// Wage supplement for night shift with labour
        /// </summary>
        public WageSupplement SupplementNightLabour { get; set; }

    }
}
