using SimpleNotes.Domain.Entities.Content;

namespace SimpleNotes.Application.Interfaces.Repositories
{
    public interface INoteRepository
    {
        Task<List<Note>> GetAllAsync();
        Task<Note?> GetByIdAsync(int id);
        Task CreateAsync(Note note);
        void Update(Note note);
        void Delete(Note note);
        Task SaveChangesAsync();
    }
}
