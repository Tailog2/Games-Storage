
using System.ComponentModel.DataAnnotations;

namespace Games_Storage.Core.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int StudioId { get; set; }
        public Studio? Studio { get; set; }
        public IEnumerable<GamesGenres> GamesGenres { get; set; } = null!;
    }
}
