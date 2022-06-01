
using System.ComponentModel.DataAnnotations;

namespace Games_Storage.Core.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<GamesGenres>? GamesGenres { get; set; }
    }
}
