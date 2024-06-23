using Contracts.Services.Catalog;
namespace Catalog.API.Controllers.Product;

public class GetAllProductsController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] Http.Request.GetAllProducts request, ISender sender) =>
        {
            var query = request.Adapt<Query.GetAllProducts>();

            var result = await sender.Send(query);

            var response = result.Adapt<Http.Response.GetAllProducts>();

            return Results.Ok(response);
        })
        .WithName("GetAllProducts")
        .Produces<Http.Response.GetAllProducts>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("GetAllProduct")
        .WithDescription("GetAllProducts");

    }
}
