using Shop.Domain.Common;

namespace Shop.Domain.Entities;

public class Category : BaseDomain
{
    public string? Name { get; set; }

    public IEnumerable<Product>? Products { get; set; }
}
