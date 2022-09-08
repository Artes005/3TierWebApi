using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = "";

        [Required]
        public int PositionRefId { get; set; }
    }
}
