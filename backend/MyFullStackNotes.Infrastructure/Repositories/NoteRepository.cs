using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFullStackNotes.Application.Interfaces;
using MyFullStackNotes.Domain.Entities;
using MyFullStackNotes.Infrastructure.Data;

namespace MyFullStackNotes.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly NotesDbContext _context;
        public NoteRepository(NotesDbContext Context)
        {
            _context = Context;
        }
        public async Task AddAsync(Note note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note is null) return;

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Note>> GetAllAsync(Guid userId)
        {
            return await _context.Notes
                .Where(n => n.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Note?> GetByIdAsync(Guid id)
        {
            return await _context.Notes.AsNoTracking().
                FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task UpdateAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }
    }
}