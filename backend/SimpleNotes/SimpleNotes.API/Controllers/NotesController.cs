using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleNotes.Application.DTOs.NoteDTOs;
using SimpleNotes.Application.Interfaces.Services;

namespace SimpleNotes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController(INoteService noteService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await noteService.GetAllAsync();
            return response.IsSuccess ? Ok(response.Data) : BadRequest(response.Error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await noteService.GetByIdAsync(id);
            return response.IsSuccess ? Ok(response.Data) : BadRequest(response.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNoteDTO noteDTO)
        {
            var response = await noteService.CreateAsync(noteDTO);
            return response.IsSuccess ? Ok(response.Data) : BadRequest(response.Error);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateNoteDTO noteDTO)
        {
            var response = await noteService.UpdateAsync(noteDTO);
            return response.IsSuccess ? Ok(response.Data) : BadRequest(response.Error);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        { 
            var response = await noteService.DeleteAsync(id); 
            return response.IsSuccess ? Ok(response.Data) : BadRequest(response.Error); 
        }

        [HttpPut("reorder")]
        public async Task<IActionResult> Reoder([FromBody] ReorderNotesDTO noteDTOs)
        {
            var response = await noteService.ReorderAsync(noteDTOs);
            return response.IsSuccess ? Ok(response.Data) : BadRequest(response.Error);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            var response = await noteService.DeleteAllAsync();
            return response.IsSuccess ? Ok() : BadRequest(response.Error);
        }
    }
}
