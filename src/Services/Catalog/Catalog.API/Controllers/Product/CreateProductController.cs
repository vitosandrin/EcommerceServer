using Contracts.Services.Catalog;

namespace Catalog.API.Controllers.Product;
public class CreateProductController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (Http.Request.CreateProduct request, ISender sender) =>
        {
            var command = request.Adapt<Command.CreateProduct>();
            var result = await sender.Send(command);
            var response = result.Adapt<Http.Response.CreateProduct>();

            return Results.Created($"/products/{response.Id}", response);
        }).WithName("CreateProduct")
        .Produces<Http.Response.CreateProduct>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}
