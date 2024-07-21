namespace E_Commerce_DAL.OrderAggregate;

public class Address
{
    public Address()
    {
    }

    public Address(string firstName, string lastName, string phoneNumber, string flat, string building, string street, string comment)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Flat = flat;
        Building = building;
        Street = street;
        Comment = comment;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Flat { get; set; }
    public string Building { get; set; }
    public string Street { get; set; }
    public string Comment { get; set; }
}