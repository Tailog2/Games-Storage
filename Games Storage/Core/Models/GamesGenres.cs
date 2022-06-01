namespace Games_Storage.Core.Models
{
    public class GamesGenres
    {
        public int GamesId { get; set; }
        public Game Game { get; set; } = null!;
        public byte GenresId { get; set; }
        public Genre Genre { get; set; } = null!;
    }
}
