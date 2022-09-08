using System.ComponentModel.DataAnnotations;

namespace _3TierWebApi.Models
{
    public class UserCreateModel
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } = "";
        [Required]
        public int PositionId { get; set; }
    }
}
