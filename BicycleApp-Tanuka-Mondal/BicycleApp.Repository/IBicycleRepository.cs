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
        Bicycle[] GetAllBicycles();
        bool AddBicycle(Bicycle bicycleObj);
        Bicycle GetBycycleById(int id);
        Bicycle GetBycycleByName(string name);
        Bicycle EditBicycle(int editId, string oldValue, string editValue);
        bool DeleteBicycle(int deleteId);

    }
}
