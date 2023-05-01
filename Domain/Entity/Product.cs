using Domain.Abstract;

namespace Domain.Entity;

public class Product : BaseEntity
{
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string Manufacturer { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }

    public string? IconURL { get; set; }
}