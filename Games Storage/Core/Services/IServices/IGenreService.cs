using Games_Storage.Core.Services.Dtos;

namespace Games_Storage.Core.Services.IServices
{
    public interface IGenreService
    {
        public IEnumerable<GenreDto> GetGenres();
        public GenreDto GetGenre(byte id);
    }
}
