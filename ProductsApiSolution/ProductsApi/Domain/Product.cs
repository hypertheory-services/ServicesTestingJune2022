namespace ProductsApi.Domain;

public class Product
{
    public string Id { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
