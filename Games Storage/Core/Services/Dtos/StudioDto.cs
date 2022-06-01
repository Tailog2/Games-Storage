using Games_Storage.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Games_Storage.Core.Services.Dtos
{
    public class StudioDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; } = null!;
    }
}
