using SimpleNotes.Application.Base;
using SimpleNotes.Application.DTOs.NoteDTOs;
using SimpleNotes.Application.Interfaces.Repositories;
using SimpleNotes.Application.Interfaces.Services;
using SimpleNotes.Domain.Entities.Content;
using System.Linq;

namespace SimpleNotes.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public async Task<Response<object>> CreateAsync(CreateNoteDTO noteDTO)
        {
            var notes = await _noteRepository.GetAllAsync();
            var order = notes.Any() ? notes.Max(x => x.Order) : 0;

            var note = new Note
            {
                Title = noteDTO.Title,
                Description = noteDTO.Description,
                Order = order + 1
            };

            await _noteRepository.CreateAsync(note);
            await _noteRepository.SaveChangesAsync();
            return Response<object>.Success(null);
        }

        public async Task<Response<object>> DeleteAllAsync()
        {
            var notes = await _noteRepository.GetAllAsync();
            if (!notes.Any()) 
            {
                return Response<object>.Success(null);
            }

            foreach (var note in notes)
            {
                _noteRepository.Delete(note);
            }
            
            await _noteRepository.SaveChangesAsync();
            return Response<object>.Success(null);
        }

        public async Task<Response<object>> DeleteAsync(int id)
        {
            var note = await _noteRepository.GetByIdAsync(id);
            if (note is null)
            {
                return Response<object>.Fail("Note not found");
            }
           
            _noteRepository.Delete(note);
            await _noteRepository.SaveChangesAsync();
            return Response<object>.Success(null);
            
        }

        public async Task<Response<List<ResponseNoteDTO>>> GetAllAsync()
        {
            var notes = await _noteRepository.GetAllAsync();
            var result = notes.Select(x => new ResponseNoteDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Order = x.Order,
            }).ToList();

            return Response<List<ResponseNoteDTO>>.Success(result);
        }

        public async Task<Response<ResponseNoteDTO>> GetByIdAsync(int id)
        {
            var note = await _noteRepository.GetByIdAsync(id);
            if (note is null)
            {
                return Response<ResponseNoteDTO>.Fail("Note not found");
            }
            var result = new ResponseNoteDTO
            {
                Id = note.Id,
                Title = note.Title,
                Description = note.Description,
                Order = note.Order,
            };

            return Response<ResponseNoteDTO>.Success(result);
        }

        public async Task<Response<object>> ReorderAsync(ReorderNotesDTO noteDTOs)
        {
            if (noteDTOs.NoteIds == null || noteDTOs.NoteIds.Count == 0)
            {
                return Response<object>.Fail("Empty reorder list");
            }

            var notes = await _noteRepository.GetAllAsync();

            if (noteDTOs.NoteIds.Count != notes.Count())
            {
                return Response<object>.Fail("Invalid reorder payload");
            }

            for (int i = 0; i < noteDTOs.NoteIds.Count; i++)
            {
                var note = notes.FirstOrDefault(x => x.Id == noteDTOs.NoteIds[i]);
                if (note is null)
                {
                    return Response<object>.Fail("Note not found");
                }

                note.Order = i + 1;
            }

            await _noteRepository.SaveChangesAsync();
            return Response<object>.Success(null);
        }

        public async Task<Response<object>> UpdateAsync(UpdateNoteDTO noteDTO)
        {
            var note = await _noteRepository.GetByIdAsync(noteDTO.Id);
            if (note is null)
            {
                return Response<object>.Fail("Note not found");
            }

            note.Title = noteDTO.Title;
            note.Description = noteDTO.Description;

            _noteRepository.Update(note);
            await _noteRepository.SaveChangesAsync();
            return Response<object>.Success(null);
        }
    }
}
