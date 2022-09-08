using System.ComponentModel.DataAnnotations;

namespace _3TierWebApi.Models
{
    public class PositionCreateModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; } = "";
    }
}

