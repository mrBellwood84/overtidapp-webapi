﻿namespace Domain.Employer
{
    /// <summary>
    /// Create new employer dto
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
