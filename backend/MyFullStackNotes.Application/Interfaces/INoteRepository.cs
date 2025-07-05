using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFullStackNotes.Domain.Entities;

namespace MyFullStackNotes.Application.Interfaces
{
    public interface INoteRepository
    {
        Task<List<Note>> GetAllAsync(Guid userId);
        Task<Note?> GetByIdAsync(Guid id);
        Task AddAsync(Note note);
        Task UpdateAsync(Note note);
        Task DeleteAsync(Guid id);
    }

}
