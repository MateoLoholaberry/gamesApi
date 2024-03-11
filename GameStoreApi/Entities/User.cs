using System.ComponentModel.DataAnnotations;

namespace GameStoreApi.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public List<Game>? Games { get; set; }
    }
}
