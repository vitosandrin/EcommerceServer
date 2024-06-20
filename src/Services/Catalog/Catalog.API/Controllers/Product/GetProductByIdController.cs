using Contracts.Services.Catalog;
namespace Catalog.API.Controllers.Product;

public class GetProductByIdController : ICarterModule

{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new Query.GetProductById(id));

            var response = result.Adapt<Http.Response.GetProductById>();

            return Results.Ok(response);
        })
          .WithName("GetProductById")
          .Produces<Http.Response.GetProductById>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .WithSummary("Get Product By Id")
          .WithDescription("Get Product By Id");
    }
}
