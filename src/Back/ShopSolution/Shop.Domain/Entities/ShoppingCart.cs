using Shop.Domain.Common;

namespace Shop.Domain.Entities
{
    public class ShoppingCart : BaseDomain
    {
        public Guid? ShoppingCartMasterId { get; set; }
        public virtual ICollection<ShoppingCartItem>? ShoppingCartItems { get; set; }
    }
}
