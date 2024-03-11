namespace GameStoreApi.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
    }
}
