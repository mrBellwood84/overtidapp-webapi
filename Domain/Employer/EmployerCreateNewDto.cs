namespace Domain.Employer
{
    /// <summary>
    /// Create new employer with data from public records. 
    /// Users suggested changes are stored as change suggestion and 
    /// must be edited by admin in front end application
    /// </summary>
    public class EmployerCreateNewDto
    {
        /// <summary>
        /// Data from public records, store directly in entity
        /// </summary>
        public EmployerEditSuggestionDto LegalData { get; set; }

        /// <summary>
        /// Change request for actual business name and address, stored as EditRequest
        /// </summary>
        public EmployerEditSuggestionDto ChangeSuggestion { get; set; }
    }
}
