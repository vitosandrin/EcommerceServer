namespace Contracts.DataTransferObjects;
public class ShoppingCartItem
{
    public int Quantity { get; set; }
    public string Color { get; set; } = default!;
    public long Price { get; set; }
    public decimal Discount { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = default!;
}
public class ShoppingCart
{
    public string UserName { get; set; } = default!;
    public List<ShoppingCartItem> Items { get; set; } = default!;
    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    public decimal TotalDiscount => Items.Sum(x => x.Discount * x.Quantity);
}

