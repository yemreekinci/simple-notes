using SimpleNotes.Application.Base;
using SimpleNotes.Application.DTOs.NoteDTOs;

namespace SimpleNotes.Application.Interfaces.Services
{
    public interface INoteService
    {
        Task<Response<List<ResponseNoteDTO>>> GetAllAsync();
        Task<Response<ResponseNoteDTO>> GetByIdAsync(int id);
        Task<Response<object>> CreateAsync(CreateNoteDTO noteDTO);
        Task<Response<object>> UpdateAsync(UpdateNoteDTO noteDTO);
        Task<Response<object>> DeleteAsync(int id);
        Task<Response<object>> ReorderAsync(ReorderNotesDTO noteDTOs);
        Task<Response<object>> DeleteAllAsync();   
    }
}
