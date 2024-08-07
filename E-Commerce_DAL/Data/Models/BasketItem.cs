namespace E_Commerce_DAL;

public class BasketItem : BaseEntity
{
    //public int Id { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string PictureUrl { get; set; }
    public string Category { get; set; }
    //public string Flavor { get; set; }
}