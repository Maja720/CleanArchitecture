using Domain.Customers;
using Domain.Products;

namespace Domain.Orders;

public class Order
{
    private readonly HashSet<LineItem> _lineItems = new();
    private Order()
    {

    }
    public Guid Id { get; private set; }
    public Guid CustomerId { get; set; }
    public static Order Create(Customer customer)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id,
        };

        return order;
    }
    public void Add(Product product)
    {
        var lineItem = new LineItem(Guid.NewGuid(), Id, product.Id, product.Price);
        _lineItems.Add(lineItem);
    }
}

public class LineItem
{
    internal LineItem(Guid id, Guid orderId, Guid productId, Money price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Price = price;

    }
    public Guid Id { get; private set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public Money Price { get; set; }
}
