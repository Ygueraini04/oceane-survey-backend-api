using System.ComponentModel.DataAnnotations;

namespace oceane_survey_api.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public bool Required { get; set; }
        public int DisplayOrder { get; set; }
        public string ConditionalLogic { get; set; }

        // Clé étrangère vers Survey
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        // Relation 1:n avec QuestionOption
        public ICollection<QuestionOption> QuestionOptions { get; set; } = new List<QuestionOption>();
    }
}
