using BicycleAPI.Models;

namespace BicycleAPI.Repository
{
    public interface IBicycleRepository
    {
        int AddBicycle(Bicycle bicycle);
        bool DeleteBicycle(Bicycle bicycleDeleteDetails);
        bool EditBicycle(Bicycle bicycleEditObject, Bicycle newBicycle);
        List<Bicycle> GetAllBicycles();
        Bicycle GetBicycleById(int bicycleId);
        Bicycle GetBicycleName(string? name);
    }
}
