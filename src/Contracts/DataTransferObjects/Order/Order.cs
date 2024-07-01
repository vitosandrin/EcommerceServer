namespace Contracts.DataTransferObjects.Order;
//TODO DRY (SAME ENUM IN Ordering.Domain)
public enum OrderStatus
{
    Draft = 1,
    Pending = 2,
    Completed = 3,
    Cancelled = 4
}
public record Address(string FirstName, string LastName, string EmailAddress, string AddressLine, string Country, string State, string ZipCode);
public record Order(
    Guid Id,
    Guid CustomerId,
    string OrderName,
    Address ShippingAddress,
    Address BillingAddress,
    Payment Payment,
    OrderStatus Status,
    List<OrderItem> OrderItems);

public record OrderItem(Guid OrderId, Guid ProductId, int Quantity, decimal Price);

public record Payment(string CardName, string CardNumber, string Expiration, string Cvv, int PaymentMethod);