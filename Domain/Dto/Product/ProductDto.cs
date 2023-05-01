namespace Domain.Dto.Product;

public class ProductDto
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string Manufacturer { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
    public string IconURL { get; set; }
}