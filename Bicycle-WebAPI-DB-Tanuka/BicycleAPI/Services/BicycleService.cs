using BicycleAPI.Exceptions;
using BicycleAPI.Models;
using BicycleAPI.Repository;

namespace BicycleAPI.Services
{
    public class BicycleService : IBicycleService
    {
        readonly IBicycleRepository _bicycleRepository;
        
        public BicycleService(IBicycleRepository bicycleRepository)
        {
            _bicycleRepository = bicycleRepository;
     
        }

        public int AddBicycle(Bicycle bicycle)
        {
            Bicycle bicycleDetails = _bicycleRepository.GetBicycleName(bicycle.Name);
            if (bicycleDetails == null )
            {
                int addResult = _bicycleRepository.AddBicycle(bicycle);
                return addResult;
            }
            else
            {
                throw new DuplicateBicycleException($"Duplicate Bicycle:{bicycle.Name}");
            }
        }

        public bool DeleteBicycle(int bicycleId)
        {
            Bicycle bicycleDeleteDetails = _bicycleRepository.GetBicycleById(bicycleId);
            if (bicycleDeleteDetails != null)
            {
                bool deleteResult = _bicycleRepository.DeleteBicycle( bicycleDeleteDetails );
                return deleteResult;
            }
            else
            {
                throw new BicycleNotFoundException("Bicycle doesn't exist");
            }
        }

        public bool EditBicycle(int id, Bicycle newBicycle)
        {
            Bicycle bicycleEditObject = _bicycleRepository.GetBicycleById(id);
            if ( bicycleEditObject != null)
            {
                bool areEqual = bicycleEditObject.Equals(newBicycle);
                if (!areEqual)
                {
                    bool editResult = _bicycleRepository.EditBicycle(bicycleEditObject, newBicycle);
                    return editResult;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                throw new BicycleNotFoundException("Bicycle doesn't exist");
            }
        }

        public List<Bicycle> GetAllBicycles()
        {
            return _bicycleRepository.GetAllBicycles();
        }
    }
}
