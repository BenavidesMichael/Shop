using Shop.Domain.Common;

namespace Shop.Domain.Entities;

public class Category : BaseDomain
{
    public string? Name { get; set; }

    public virtual ICollection<Product>? Products { get; set; }
}
