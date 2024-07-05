using BicycleAPI.Models;
using System.Reflection;

namespace BicycleAPI.Repository
{
    public class BicycleRepository : IBicycleRepository
    {
        List<Bicycle> _bicycles;
        public BicycleRepository()
        {
            _bicycles = new List<Bicycle>();
        }
        public int AddBicycle(Bicycle bicycle)
        {
            if(_bicycles.Count == 0)
            {
                bicycle.Id = 1;
            }
            else
            {
                bicycle.Id = _bicycles.Max(b =>  b.Id) + 1;
            }
            _bicycles.Add(bicycle);
            return 1;
        }

        public bool DeleteBicycle(Bicycle bicycleDeleteDetails)
        {
            return _bicycles.Remove(bicycleDeleteDetails);
        }

        public bool EditBicycle(Bicycle bicycleEditObject, Bicycle newBicycle)
        {
            bicycleEditObject.Name = newBicycle.Name;
            bicycleEditObject.Category = newBicycle.Category;
            bicycleEditObject.Price = newBicycle.Price;
            return true;
        }

        public List<Bicycle> GetAllBicycles()
        {
            return _bicycles;
        }

        public Bicycle? GetBicycleById(int bicycleId)
        {
            return _bicycles.Find(b => b.Id == bicycleId);
        }

        public Bicycle? GetBicycleName(string? name)
        {
            return _bicycles.Where(b => b.Name == name).FirstOrDefault();
        }
    }
}
