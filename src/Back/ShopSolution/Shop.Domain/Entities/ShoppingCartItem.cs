using Shop.Domain.Common;

namespace Shop.Domain.Entities
{
    public class ShoppingCartItem : BaseDomain
    {
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string? Image { get; set; }
        public Guid? ShoppingCartMasterId { get; set; }


        public int ShoppingCartId { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
