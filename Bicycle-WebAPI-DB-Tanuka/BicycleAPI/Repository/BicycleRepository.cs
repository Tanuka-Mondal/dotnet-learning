using BicycleAPI.Context;
using BicycleAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleAPI.Repository
{
    public class BicycleRepository : IBicycleRepository
    {
        readonly BicycleDbContext _bicycleDbContext;
        public BicycleRepository(BicycleDbContext bicycleDbContext)
        {
            _bicycleDbContext = bicycleDbContext;
        }
        public int AddBicycle(Bicycle bicycle)
        {           
            _bicycleDbContext.Bicycles.Add(bicycle);
            int changes = _bicycleDbContext.SaveChanges();
            return changes;
        }

        public bool DeleteBicycle(Bicycle bicycleDeleteDetails)
        {
            _bicycleDbContext.Bicycles.Remove(bicycleDeleteDetails);
            int changes = _bicycleDbContext.SaveChanges();
            return changes>0;
        }

        public bool EditBicycle(Bicycle bicycleEditObject, Bicycle newBicycle)
        {
            bicycleEditObject.Name = newBicycle.Name;
            bicycleEditObject.Category = newBicycle.Category;
            bicycleEditObject.Price = newBicycle.Price;

            _bicycleDbContext.Entry(bicycleEditObject).State = EntityState.Modified;
            int changes = _bicycleDbContext.SaveChanges();
            return changes > 0;
        }

        public List<Bicycle> GetAllBicycles()
        {
            return _bicycleDbContext.Bicycles.ToList();
        }

        public Bicycle? GetBicycleById(int bicycleId)
        {
            return _bicycleDbContext.Bicycles.Where(b => b.Id == bicycleId).FirstOrDefault();
        }

        public Bicycle? GetBicycleName(string? name)
        {
            return _bicycleDbContext.Bicycles.Where(b => b.Name == name).FirstOrDefault();
        }
    }
}
