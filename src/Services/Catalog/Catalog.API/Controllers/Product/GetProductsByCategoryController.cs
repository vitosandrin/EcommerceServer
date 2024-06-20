using Contracts.Services.Catalog;
using Microsoft.AspNetCore.Routing;

namespace Catalog.API.Controllers.Product;

public class GetProductsByCategoryController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}",
            async (string category, ISender sender) =>
            {
                var result = await sender.Send(new Query.GetProductsByCategory(category));

                var response = result.Adapt<Http.Response.GetProductsByCategory>();

                return Results.Ok(response);
            })
        .WithName("GetProductByCategory")
        .Produces<Http.Response.GetProductsByCategory>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Category")
        .WithDescription("Get Product By Category");
    }
}
