namespace oceane_survey_api.Models
{
    public class SurveyRecipient
    {
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public int RecipientId { get; set; }
        public Recipient Recipient { get; set; }
    }
}
