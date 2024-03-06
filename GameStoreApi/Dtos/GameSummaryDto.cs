namespace GameStoreApi.Dtos
{
    public class GameSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
