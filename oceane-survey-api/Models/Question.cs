using oceane_survey_api.Helpers.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oceane_survey_api.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public bool? Required { get; set; }
        public int DisplayOrder { get; set; }
        public string ConditionalLogic { get; set; }

        [ForeignKey("SurveyId")]
        public long SurveyId { get; set; }
        public ICollection<QuestionOption> QuestionOptions { get; set; } = new List<QuestionOption>();
    }
}
