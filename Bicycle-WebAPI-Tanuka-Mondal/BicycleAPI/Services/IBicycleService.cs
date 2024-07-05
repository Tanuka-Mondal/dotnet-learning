using BicycleAPI.Models;

namespace BicycleAPI.Services
{
    public interface IBicycleService
    {
        int AddBicycle(Bicycle bicycle);
        bool DeleteBicycle(int bicycleId);
        bool EditBicycle(int id, Bicycle newBicycle);
        List<Bicycle> GetAllBicycles();
    }
}
