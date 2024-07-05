using Bicycle_Web_Tanuka.Models;
using Microsoft.EntityFrameworkCore;

namespace Bicycle_Web_Tanuka.Context
{
    public class BicycleDbContext : DbContext
    {
        public BicycleDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Bicycle> Bicycles { get; set;}
    }
}
