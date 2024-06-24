namespace Basket.API.Controllers.Basket;

public class GetBasketController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new Query.GetBasket(userName));

            var response = result.Adapt<Http.Response.GetBasket>();

            return Results.Ok(response);
        }).WithName("GetBasketByUserName")
        .Produces<Http.Response.GetBasket>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Basket  By UserName")
        .WithDescription("Get Basket  By UserName");
    }
}
