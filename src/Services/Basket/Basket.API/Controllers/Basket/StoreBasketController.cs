namespace Basket.API.Controllers.Basket;

public class StoreBasketController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (Http.Request.StoreBasket request, ISender sender) =>
        {
            var command = request.Adapt<Command.StoreBasket>();

            var result = await sender.Send(command);

            var response = result.Adapt<Http.Response.StoreBasket>();

            return Results.Created($"/basket/{response.UserName}", response);

        }).WithName("StoreBasket")
        .Produces<Http.Response.StoreBasket>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Store Basket")
        .WithDescription("Store Basket");
    }
}
