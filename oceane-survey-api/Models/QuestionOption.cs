using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oceane_survey_api.Models
{
    public class QuestionOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Text { get; set; }
        public int DisplayOrder { get; set; }

        [ForeignKey("QuestionId")]
        public long QuestionId { get; set; }
    }
}
