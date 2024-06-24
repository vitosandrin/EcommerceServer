namespace Basket.API.Controllers.Basket;

public class DeleteBasketController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket", async (Http.Request.DeleteBasket request, ISender sender) =>
        {
            var command = request.Adapt<Command.DeleteBasket>();

            var result = await sender.Send(command);

            var response = result.Adapt<Http.Response.DeleteBasket>();

            return Results.NoContent();
        }).WithName("DeleteBasket")
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Basket")
        .WithDescription("Delete Basket");
    }
}
}
