using Domain.Products;

namespace Domain.Orders;

public class LineItem
{
    internal LineItem(LineItemId id, OrderId orderId, ProductId productId, Money price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Price = price;

    }
    public LineItemId Id { get; private set; }
    public OrderId OrderId { get; set; }
    public ProductId ProductId { get; set; }
    public Money Price { get; set; }
}
