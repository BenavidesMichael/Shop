using Shop.Domain.Common;

namespace Shop.Domain.Entities;

public class Product : BaseDomain
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int Raiting { get; set; }
    public int Stock { get; set; }
    public bool IsAvaible { get; set; }
    public string? BuyerName { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    
    public virtual ICollection<Image>? Images { get; set; }
    public virtual ICollection<Review>? Reviews { get; set; }

}
