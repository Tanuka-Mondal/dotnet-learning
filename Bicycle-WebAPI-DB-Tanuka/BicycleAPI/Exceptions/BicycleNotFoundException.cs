namespace BicycleAPI.Exceptions
{
    public class BicycleNotFoundException:ApplicationException
    {
        public BicycleNotFoundException()
        {
            
        }
        public BicycleNotFoundException(string message) : base(message) { }
    }
}
