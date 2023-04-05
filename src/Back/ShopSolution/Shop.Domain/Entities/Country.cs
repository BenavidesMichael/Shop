using Shop.Domain.Common;

namespace Shop.Domain.Entities;

public class Country : BaseDomain
{
    public string? Name { get; set; }
    public string? ISO2 { get; set; }
    public string? ISO3 { get; set; }
}
