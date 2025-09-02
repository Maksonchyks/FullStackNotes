using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFullStackNotes.Domain.Entities;

namespace MyFullStackNotes.Application.Interfaces
{
    public interface INoteService
    {
        Task AddNoteAsync(string title, string? description, Guid userId);
        Task<List<Note>> GetAllNotesAsync(Guid userId);
        Task<Note?> GetNoteByIdAsync(Guid noteId);
        Task UpdateNoteAsync(Guid noteId, string? newTitle, string newDescription);
        Task DeleteNoteAsync(Guid noteId);
    }
}
