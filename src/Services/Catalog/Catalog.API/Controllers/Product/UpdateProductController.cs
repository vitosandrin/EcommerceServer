using Contracts.Services.Catalog;

namespace Catalog.API.Controllers.Product;

public class UpdateProductController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products",
            async (Http.Request.UpdateProduct request, ISender sender) =>
            {
                var command = request.Adapt<Command.UpdateProduct>();

                var result = await sender.Send(command);

                var response = result.Adapt<Http.Response.UpdateProduct>();

                return Results.Ok(response);
            })
            .WithName("UpdateProduct")
            .Produces<Http.Response.UpdateProduct>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
    }
}
