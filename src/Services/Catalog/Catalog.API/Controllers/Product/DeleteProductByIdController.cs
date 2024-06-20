using Contracts.Services.Catalog;

namespace Catalog.API.Controllers.Product;

public class DeleteProductByIdController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new Command.DeleteProductById(id));

            var response = result.Adapt<Http.Response.DeleteProductById>();

            return Results.Ok(response);
        })
        .WithName("DeleteProduct")
        .Produces<Http.Response.DeleteProductById>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");
    }
}
