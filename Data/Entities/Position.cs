using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        [ForeignKey("PositionRefId")]
        public ICollection<User> Users { get; set; }  = new List<User>();
    }
}
