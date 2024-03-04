using System.ComponentModel.DataAnnotations;

namespace GameStoreApi.Dtos
{
    public record class CreateGameDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Genre { get; set; }

        [Range(1, 200)]
        public decimal Price { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
