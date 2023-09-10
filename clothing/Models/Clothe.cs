namespace clothing.Models
{
    public class Clothe
    {
        public int ID { get; set; }
        public ClotheTypes ClotheTypes { get; set; }
        public int Quantity { get; set; }
        public string BrandName { get; set; }
    }
    public enum ClotheTypes
    {
        Coat, Pants, Shoes
    }
  
    
}
