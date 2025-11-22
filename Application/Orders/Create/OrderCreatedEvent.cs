namespace Application.Orders.Create;

internal sealed class OrderCreatedEvent
{
    public Guid OrderId { get; }
    public OrderCreatedEvent(Guid orderId)
    {
        OrderId = orderId;
    }
}
