
using Games_Storage.Core.Services.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Games_Storage.Core.Models
{
    public class Studio
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; } = null!;
        public IEnumerable<Game>? Games { get; set; }
    }
}
