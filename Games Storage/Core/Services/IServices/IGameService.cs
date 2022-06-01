
using Games_Storage.Core.Services.Dtos;

namespace Games_Storage.Core.Services.IServices
{
    public interface IGameService
    {
        public IEnumerable<GameDto> GetGames(string? query = null);
        public GameDto GetGame(int id);
        public GameDto CreateGame(NewGameDto gameDto);
        public void UpdateGame(int id, EditGameDto gameDto);
        public void DeleteGame(int id);
        public IEnumerable<GameDto> GetGamesByGenre(byte genreId);
    }
}
