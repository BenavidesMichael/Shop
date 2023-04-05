using Shop.Domain.Common;

namespace Shop.Domain.Entities;

public class Order : BaseDomain
{
    public string? Buyer { get; set; }
    public string? BuyerUserName { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
    public decimal Taxe { get; set; }
    public decimal SendingPrice { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    
    public string? PaymentIntentId { get; set; }
    public string? ClientSecret { get; set; }
    public string? StripeApiKey { get; set; }


    public OrderAddress? OrderAddress { get; set; }
    public IReadOnlyList<OrderItem>? OrderItems { get; set; }
}
