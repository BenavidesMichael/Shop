using Shop.Domain.Common;

namespace Shop.Domain.Entities;

public class Address : BaseDomain
{
    public string? Street { get; set; }
    public string? Number { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }

    public string? Username { get; set; }
    public string? Country { get; set; }
}
