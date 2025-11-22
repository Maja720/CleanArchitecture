using Domain.Customers;
using Domain.Primitives;
using Domain.Products;

namespace Domain.Orders;

public class Order : Entity
{
    private Order()
    {

    }
    public OrderId Id { get; private set; }
    public CustomerId CustomerId { get; private set; }
    public ICollection<LineItem> LineItems { get; private set; } = new List<LineItem>();
    public static Order Create(CustomerId customerId)
    {
        var order = new Order
        {
            Id = new OrderId(Guid.NewGuid()),
            CustomerId = customerId,
        };

        order.Raise(new OrderCreatedDomainEvent(Guid.NewGuid(), order.Id));

        return order;
    }
    public void AddLineItem(ProductId productId, Money price)
    {
        var lineItem = new LineItem(new LineItemId(Guid.NewGuid()),
            Id,
            productId,
            price);

        LineItems.Add(lineItem);

        Raise(new LineItemRemovedDomainEvent(Guid.NewGuid(), Id, lineItem.Id));
    }
}
