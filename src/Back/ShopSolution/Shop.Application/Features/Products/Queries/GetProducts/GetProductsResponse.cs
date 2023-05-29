namespace Shop.Application.Features.Products.Queries.GetProducts;

public class GetProductsResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public List<string> Images { get; set; } = null!;
    public List<string> Reviews { get; set; } = null!;
}