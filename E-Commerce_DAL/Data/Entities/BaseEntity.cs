using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_DAL;

public class BaseEntity
{
    public int Id { get; set; }

    public bool IsDelete { get; set; } = false;
}
