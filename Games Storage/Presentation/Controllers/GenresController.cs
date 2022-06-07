using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Games_Storage.Core.Models;
using Games_Storage.Persistence;
using Games_Storage.Core.Services.IServices;
using Games_Storage.Core.Services.Dtos;

namespace Games_Storage.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: api/Genres
        [HttpGet]
        public ActionResult<IEnumerable<GenreDto>> GetGenres()
        {
            return new ActionResult<IEnumerable<GenreDto>>(_genreService.GetGenres());
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public ActionResult<GenreDto> GetGenre(byte id)
        {
            return new ActionResult<GenreDto>(_genreService.GetGenre(id));
        }
    }
}
