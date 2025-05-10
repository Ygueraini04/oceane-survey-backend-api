using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using oceane_survey_api.Models;

namespace oceane_survey_api.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly SurveyContext _context;

        public SurveyService(SurveyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Survey>> GetAllSurveysAsync()
        {
            return await _context.Surveys.ToListAsync();
        }

        public async Task<Survey> GetSurveyByIdAsync(int id)
        {
            return await _context.Surveys.FindAsync(id);
        }

        public async Task<Survey> CreateSurveyAsync(Survey survey)
        {
            survey.CreationDate = DateTime.UtcNow;
            survey.LastModifiedDate = DateTime.UtcNow;

            _context.Surveys.Add(survey);
            await _context.SaveChangesAsync();
            return survey;
        }

        public async Task<Survey> UpdateSurveyAsync(int id, Survey updatedSurvey)
        {
            var existingSurvey = await _context.Surveys.FindAsync(id);
            if (existingSurvey == null) return null;

            existingSurvey.Title = updatedSurvey.Title;
            existingSurvey.Description = updatedSurvey.Description;
            existingSurvey.Status = updatedSurvey.Status;
            existingSurvey.LastModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existingSurvey;
        }

        public async Task<bool> DeleteSurveyAsync(int id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            if (survey == null) return false;

            _context.Surveys.Remove(survey);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
