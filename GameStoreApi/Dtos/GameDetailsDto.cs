namespace GameStoreApi.Dtos
{
    public record class GameDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Genre { get; set; }
        public decimal Price { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
