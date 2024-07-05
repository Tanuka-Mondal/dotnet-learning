using System.ComponentModel.DataAnnotations;

namespace Bicycle_Web_Tanuka.Models
{
    public class BicycleDto
    {
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Category { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
