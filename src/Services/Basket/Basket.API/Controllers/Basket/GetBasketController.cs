namespace Basket.API.Controllers.Basket;

public class GetBasketController : ICarterModule
{
    public void AddRoutes(IRouteBuilder routeBuilder)
    {
        routeBuilder.Get("basket", async () =>
        {
            var username = routeData.Get<string>("username");
            var response = await req.SendRequestAsync<Http.Response.GetBasket>(Http.Request.GetBasket(username));
            return res.WriteAsJsonAsync(response.Cart);
        });
    }
}
