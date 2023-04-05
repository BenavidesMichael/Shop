using Shop.Domain.Common;

namespace Shop.Domain.Entities
{
    public class OrderItem : BaseDomain
    {
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int ProductItemId { get; set; }
        public string? ProductName { get; set; }

        public string? ImageURL { get; set;}
    }
}
