namespace Contracts.DataTransferObjects;
public record ShoppingCartItem(int Quantity, string Color, long Price, Guid ProductId, string ProductName);
public record ShoppingCart(string UserName, List<ShoppingCartItem> Items)
{
    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

    public ShoppingCart() : this(string.Empty, new List<ShoppingCartItem>())
    {
    }
}