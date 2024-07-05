namespace BicycleApp.Models
{
    public class Bicycle
    {
        #region Parameters
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
    
        public decimal Price { get; set; }
        #endregion

        #region Methods
        public string Display()
        {
            return $"{Id}\t{Name}\t{Category}\t{Price}";
        }
        #endregion
    }


}
