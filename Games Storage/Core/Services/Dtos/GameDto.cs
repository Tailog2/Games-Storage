
namespace Games_Storage.Core.Services.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public StudioDto? Studio { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; } = null!;
    }
}
