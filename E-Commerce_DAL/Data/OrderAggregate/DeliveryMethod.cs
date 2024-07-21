namespace E_Commerce_DAL;

public class DeliveryMethod : BaseEntity
{
    public string Area { get; set; }
    public string DeliveryTime { get; set; }
    //public string Description { get; set; }
    public decimal Price { get; set; }
}