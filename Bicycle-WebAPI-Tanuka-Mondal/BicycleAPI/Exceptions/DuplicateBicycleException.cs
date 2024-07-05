namespace BicycleAPI.Exceptions
{
    public class DuplicateBicycleException:ApplicationException
    {
        public DuplicateBicycleException()
        {

        }
        public DuplicateBicycleException(string message) : base(message) { }
    }
}
