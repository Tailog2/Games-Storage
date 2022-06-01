using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Games_Storage.Persistence;
using Games_Storage.Core.Services.IServices;
using Games_Storage.Core.Services.Dtos;

namespace Games_Storage.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudiosController : ControllerBase
    {
        private readonly IStudioService _studioService;

        public StudiosController(IStudioService studioService)
        {
            _studioService = studioService;
        }

        // GET: api/Studios
        [HttpGet]
        public ActionResult<IEnumerable<StudioDto>> GetStudio(string? query = null)
        {
            return new ActionResult<IEnumerable<StudioDto>>(_studioService.GetStudios(query));
        }

        // GET: api/Studios/5
        [HttpGet("{id}")]
        public ActionResult<StudioDto> GetStudio(int id)
        {
            return new ActionResult<StudioDto>(_studioService.GetStudio(id));
        }

        // PUT: api/Studios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutStudio(int id, StudioDto studioDto)
        {
            _studioService.UpdateStudio(id, studioDto);
            return NoContent();
        }

        // POST: api/Studios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<StudioDto> PostStudio(StudioDto studio)
        {
            var studioDto = _studioService.CreateStudio(studio);

            return CreatedAtAction(
                nameof(GetStudio),
                new { id = studioDto.Id },
                studioDto);
        }

        // DELETE: api/Studios/5
        [HttpDelete("{id}")]
        public ActionResult DeleteStudio(int id)
        {
            _studioService.DeleteStudio(id);
            return NoContent();
        }
    }
}
