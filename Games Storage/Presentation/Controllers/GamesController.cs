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
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        // GET: api/Games
        [HttpGet]
        public ActionResult<IEnumerable<GameDto>> GetGames(string? query = null)
        {
            return new ActionResult<IEnumerable<GameDto>>(_gameService.GetGames(query));
        }

        // GET: api/GamesByGenre/
        [HttpGet("Genre/{id}")]
        public ActionResult<IEnumerable<GameDto>> GetGamesByGenre(byte id)
        {
            return new ActionResult<IEnumerable<GameDto>>(_gameService.GetGamesByGenre(id));
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public ActionResult<GameDto> GetGame(int id)
        {
            return new ActionResult<GameDto>(_gameService.GetGame(id));
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutGame(int id, EditGameDto game)
        {
            _gameService.UpdateGame(id, game);
            return NoContent();
        }

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<GameDto> PostGame(NewGameDto game)
        {
            var gameDto = _gameService.CreateGame(game);

            return CreatedAtAction(
                nameof(GetGame),
                new { id = gameDto.Id },
                gameDto);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public ActionResult DeleteGame(int id)
        {
            _gameService.DeleteGame(id);
            return NoContent();
        }
    }
}
