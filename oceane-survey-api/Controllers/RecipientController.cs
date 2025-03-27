using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oceane_survey_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/recipients")]
[ApiController]
public class RecipientController : ControllerBase
{
    private readonly SurveyContext _context;

    public RecipientController(SurveyContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Ajoute un destinataire (recipient)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateRecipient([FromBody] Recipient recipient)
    {
        if (recipient == null)
        {
            return BadRequest("Recipient data is required.");
        }

        _context.Recipients.Add(recipient);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRecipientById), new { id = recipient.Id }, recipient);
    }

    /// <summary>
    /// Récupère un recipient par ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecipientById(long id)
    {
        var recipient = await _context.Recipients.FindAsync(id);
        if (recipient == null) return NotFound("Recipient not found.");

        return Ok(recipient);
    }

    /// <summary>
    /// Supprime un destinataire
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipient(long id)
    {
        var recipient = await _context.Recipients.FindAsync(id);
        if (recipient == null) return NotFound("Recipient not found.");

        _context.Recipients.Remove(recipient);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
