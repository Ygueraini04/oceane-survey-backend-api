using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oceane_survey_api.Models;
using oceane_survey_api.Services;

namespace oceane_survey_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        /// <summary>
        /// Crée un nouveau survey
        /// </summary>
        /// 
        [HttpPost]
        //[Route("CreateSurvey")]
        public async Task<IActionResult> CreateSurvey([FromBody] Survey survey)
        {
            if (survey == null)
            {
                return BadRequest("Survey data is required.");
            }

            var createdSurvey = await _surveyService.CreateSurveyAsync(survey);
            return CreatedAtAction(nameof(GetSurveyById), createdSurvey);
        }

        /// <summary>
        /// Récupère tous les surveys
        /// </summary>
        [HttpGet]
        //[Route("GetAllSurveys")]
        public async Task<ActionResult<IEnumerable<Survey>>> GetAllSurveys()
        {
            var surveys = await _surveyService.GetAllSurveysAsync();
            return Ok(surveys);
        }

        /// <summary>
        /// Récupère un survey par ID
        /// </summary>
        [HttpGet("{id}")]
        //[Route("GetSurveyById")]
        public async Task<IActionResult> GetSurveyById(int id)
        {
            var survey = await _surveyService.GetSurveyByIdAsync(id);
            if (survey == null) return NotFound("Survey not found.");
            return Ok(survey);
        }

        /// <summary>
        /// Modifie un survey existant
        /// </summary>
        [HttpPut("{id}")]
        //[Route("UpdateSurvey")]
        public async Task<IActionResult> UpdateSurvey(int id, [FromBody] Survey updatedSurvey)
        {
            if (updatedSurvey == null) return BadRequest("Invalid survey data.");

            var survey = await _surveyService.UpdateSurveyAsync(id, updatedSurvey);
            if (survey == null) return NotFound("Survey not found.");

            return Ok(survey);
        }

        /// <summary>
        /// Supprime un survey
        /// </summary>
        [HttpDelete("{id}")]
        //[Route("DeleteSurveyById")]        
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            var deleted = await _surveyService.DeleteSurveyAsync(id);
            if (!deleted) return NotFound("Survey not found.");

            return NoContent();
        }
    }
}
