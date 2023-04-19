using Shop.Domain.Common;

namespace Shop.Domain.Entities;

public class Country : BaseDomain
{
    public string? Name { get; set; }
    public string? Iso2 { get; set; }
    public string? Iso3 { get; set; }
}
