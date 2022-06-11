namespace Domain.Agreements
{
    /// <summary>
    /// Entity for agreement rule
    /// </summary>
    public class AgreementRule
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Set rate if any
        /// </summary>
        public double? Rate { get; set; }

        /// <summary>
        /// Set a fixed limit if any
        /// </summary>
        public double? Limit { get; set; }

        /// <summary>
        /// Used if a rule is set for a period, days or weeks
        /// </summary>
        public double? Period { get; set; }

        /// <summary>
        /// Set max hours per week if any
        /// </summary>
        public double? MaxHourWeek { get; set; }

        /// <summary>
        /// Set max hours per month if any
        /// </summary>
        public double? MaxHourMonth { get; set; }

        /// <summary>
        /// Set max hours per year if any
        /// </summary>
        public double? MaxHourYear { get; set; }

#nullable enable
        /// <summary>
        /// Paragraph in agreement
        /// </summary>
        public string? Paragraph { get; set; }

        public List<ParagraphText>? Reference { get; set; }
#nullable disable
    }
}
