using Shop.Domain.Common;

namespace Shop.Domain.Entities;

public class Image : BaseDomain
{
    public string? Url { get; set; }
    public string? PublicCode { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
