using System.Collections.Generic;
using System.Threading.Tasks;
using oceane_survey_api.Models;

namespace oceane_survey_api.Services
{
    public interface ISurveyService
    {
        Task<IEnumerable<Survey>> GetAllSurveysAsync();
        Task<Survey> GetSurveyByIdAsync(int id);
        Task<Survey> CreateSurveyAsync(Survey survey);
        Task<Survey> UpdateSurveyAsync(int id, Survey updatedSurvey);
        Task<bool> DeleteSurveyAsync(int id);
    }
}
