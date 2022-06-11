namespace Domain.Agreements
{
    public class ParagraphText
    {
        /// <summary>
        /// Entity Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Paragaph text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Language code for text
        /// </summary>
        public string Lang { get; set; }
    }
}
