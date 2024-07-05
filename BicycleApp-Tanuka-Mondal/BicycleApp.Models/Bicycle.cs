namespace BicycleApp.Models
{
    public class Bicycle
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
    
        public decimal Price { get; set; }

        public string Display()
        {
            return $"{Id}\t{Name}\t{Category}\t{Price}";
        }
    }

    
}
