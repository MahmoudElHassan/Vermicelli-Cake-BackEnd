using System.Runtime.Serialization;

namespace E_Commerce_DAL;

public enum OrderStatus
{
    [EnumMember(Value = "Pending")]
    Pending,

    [EnumMember(Value = "Delivered")]
    Delivered

    //[EnumMember(Value = "Payment Failed")]
    //PaymentFailed
}