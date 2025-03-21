using System.ComponentModel.DataAnnotations;

namespace oceane_survey_api.Models
{
    public class Recipient
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Type { get; set; }

        // Relation n:m avec Survey
        public ICollection<SurveyRecipient> SurveyRecipients { get; set; } = new List<SurveyRecipient>();
    }
}
