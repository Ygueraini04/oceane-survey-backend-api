using System.ComponentModel.DataAnnotations;

namespace oceane_survey_api.Models
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Status { get; set; }

        // Relation n:m avec Recipient
        public ICollection<SurveyRecipient> SurveyRecipients { get; set; } = new List<SurveyRecipient>();

        // Relation 1:n avec Question
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
