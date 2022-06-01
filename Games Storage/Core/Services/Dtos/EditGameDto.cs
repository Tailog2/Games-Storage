using Games_Storage.Core.Services.Validators;
using System.ComponentModel.DataAnnotations;

namespace Games_Storage.Core.Services.Dtos
{
    public class EditGameDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; } = null!;
        [Required]
        public int StudioId { get; set; }
        [Required]
        [NotEmptyListAttribute]
        public IEnumerable<byte> GenresIds { get; set; } = null!;
    }
}
