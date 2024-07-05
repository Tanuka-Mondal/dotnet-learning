using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Bicycle_Web_Tanuka.Models
{
    public class Bicycle
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Category { get; set; }
        [Precision(16,2)]
        public decimal Price { get; set; }

    }
}
