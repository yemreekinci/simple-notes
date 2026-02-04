using Microsoft.EntityFrameworkCore;
using SimpleNotes.Application.Interfaces.Repositories;
using SimpleNotes.Domain.Entities.Content;
using SimpleNotes.Infrastructure.Persistance;

namespace SimpleNotes.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;
        public NoteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Note note)
        {
            await _context.Notes.AddAsync(note);
        }

        public void Delete(Note note)
        {
            _context.Notes.Remove(note);
        }

        public async Task<List<Note>> GetAllAsync()
        {
            return await _context.Notes
                .OrderBy(x => x.Order)
                .ToListAsync();
        }

        public async Task<Note?> GetByIdAsync(int id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Note note)
        {
            _context.Notes.Update(note);
        }
    }
}
