namespace Basket.API.Controllers.Basket;

public class DeleteBasketController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
        {

            var result = await sender.Send(new Command.DeleteBasket(userName));

            var response = result.Adapt<Http.Response.DeleteBasket>();

            return Results.NoContent();
        }).WithName("DeleteBasket")
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Basket")
        .WithDescription("Delete Basket");
    }
}
