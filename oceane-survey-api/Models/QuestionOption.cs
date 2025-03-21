using System.ComponentModel.DataAnnotations;

namespace oceane_survey_api.Models
{
    public class QuestionOption
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int DisplayOrder { get; set; }

        // Clé étrangère vers Question
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
