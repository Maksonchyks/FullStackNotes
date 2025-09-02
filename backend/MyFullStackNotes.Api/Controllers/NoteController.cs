using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFullStackNotes.Api.DTO.Note;
using MyFullStackNotes.Application.Interfaces;
using MyFullStackNotes.Domain.Entities;

namespace MyFullStackNotes.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost("notes")]
        public async Task<ActionResult<Note>> CreateNote([FromBody] CreateNoteRequest crNoteRequest)
        {

            await _noteService.AddNoteAsync(crNoteRequest.Title, crNoteRequest.Description, crNoteRequest.UserId);
            return Ok();

        }

        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteNote([FromRoute] Guid id) 
        {
            var note = await _noteService.GetNoteByIdAsync(id);
            if (note == null) return NotFound();

            await _noteService.DeleteNoteAsync(id);
            return NoContent();
        }

        [HttpGet("notes")]
        public async Task<ActionResult<List<Note>>> GetAllNotes(Guid userId)
        {
            var notes = await _noteService.GetAllNotesAsync(userId);
            return Ok(notes);

        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<Note?>> GetNote([FromRoute] Guid id)
        {
            var note = await _noteService.GetNoteByIdAsync(id);
            if (note == null) return NotFound();
            return Ok(note);

        }

        [HttpPatch("id/{id}")]
        public async Task<ActionResult> UpdateNote([FromRoute] Guid id, [FromBody] UpdateNoteRequest upNoteRequest)
        {

            await _noteService.UpdateNoteAsync(id, upNoteRequest.NewTitle, upNoteRequest.Newdescription);
            return NoContent();

        }


    }
}
