using BicycleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleApp.Repository
{
    public interface IBicycleRepository
    {
        Bicycle IsBicycleExist(Bicycle bicycleObj);
        List<Bicycle> GetAllBicycles();
        bool AddBicycle(Bicycle bicycleObj);
        Bicycle GetBicycleById(int id);
        Bicycle GetBicycleByName(string name);
        Bicycle EditBicycle(int editId, string oldValue, string editValue);
        bool DeleteBicycle(int deleteId);

    }
}
