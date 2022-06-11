namespace Domain.Agreements.CollectiveAgreement
{
    /// <summary>
    /// Data model for wage supplement. Defines a period withing start and end as clock string.
    /// Wagesupplement model is designed for daily supplements defined by time of day.
    /// </summary>
    public class WageSupplement
    {
        /// <summary>
        ///  Entity id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Start represented as clock string, example "00:00:00"
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// End represented as clock string, example "23:59:59",
        /// </summary>
        public string End { get; set; }

        /// <summary>
        /// Rate in NOK for wage supplement
        /// </summary>
        public double Rate { get; set; }
    }
}
