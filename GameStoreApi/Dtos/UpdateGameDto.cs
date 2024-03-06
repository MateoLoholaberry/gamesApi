using System.ComponentModel.DataAnnotations;

namespace GameStoreApi.Dtos
{
    public record class UpdateGameDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Range(1, 200)]
        public decimal Price { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
