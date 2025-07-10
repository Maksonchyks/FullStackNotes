using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MyFullStackNotes.Application.Interfaces;
using MyFullStackNotes.Domain.Entities;

namespace MyFullStackNotes.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly ILogger<NoteService> _logger;

        public NoteService(INoteRepository noteRepository,
                           ILogger<NoteService> logger)
        {
            _noteRepository = noteRepository;
            _logger = logger;
        }
        public async Task AddNoteAsync(string tittle, string? description, Guid userId)
        {
            if (string.IsNullOrWhiteSpace(tittle))
                throw new ArgumentException("Title cannot be empty.", nameof(tittle));

            var note = new Note(tittle, description, userId);
            await _noteRepository.AddAsync(note);

            _logger.LogInformation("Note {NoteId} created for user {UserId}", note.Id, userId);
        }

        public async Task DeleteNoteAsync(Guid id)
        {
            await _noteRepository.DeleteAsync(id);
            _logger.LogInformation("Note {NoteId} deleted", id);
        }

        public Task<List<Note>> GetAllNotesAsync(Guid userId)
        {
            return _noteRepository.GetAllAsync(userId);
        }

        public Task<Note?> GetNoteByIdAsync(Guid id)
        {
            return _noteRepository.GetByIdAsync(id);
        }

        public async Task UpdateNoteAsync(Guid id, string? newTitle, string newDescription)
        {
            var note = await _noteRepository.GetByIdAsync(id);
            if (note is null)
            {
                _logger.LogWarning("Note with ID {NoteId} not found for update", id);
                return;
            }

            if (!string.IsNullOrWhiteSpace(newTitle))
                note.ChangeTitle(newTitle);

            note.ChangeDescription(newDescription);

            await _noteRepository.UpdateAsync(note);
            _logger.LogInformation("Note {NoteId} updated", id);
        }
    }
}
