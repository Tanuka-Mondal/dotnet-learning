using BicycleAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleAPI.Context
{
    public class BicycleDbContext : DbContext
    {
        public BicycleDbContext(DbContextOptions<BicycleDbContext> options) : base(options) 
        { 
            Database.EnsureCreated();
        }
        public DbSet<Bicycle> Bicycles { get; set; }
    }
}
