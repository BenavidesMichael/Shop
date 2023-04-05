using Shop.Domain.Common;

namespace Shop.Domain.Entities;

public class Address : BaseDomain
{
    public string? Street { get; set; }
    public string? Number { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }


    public int UserId { get; set; }
    public User? User { get; set; }

    public int CountryId { get; set; }
    public Country? Country { get; set; }
}
