using Shop.Domain.Common;

namespace Shop.Domain.Entities;

public class Review : BaseDomain
{
    public string? Name { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }
}