using Contracts.DataTransferObjects;
using Marten;
using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        session.DeleteObjects(GetPreconfiguredProducts());
        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
    {
        new Product(
            new Guid("b786103d-c621-4f5a-b498-23452610f88c"),
            "HTC U11+ Plus",
            new List<string> { "Smart Phone" },
            "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            02031
        ),
        new Product(
            new Guid("c4bbc4a2-4555-45d8-97cc-2a99b2167bff"),
            "LG G7 ThinQ",
            new List<string> { "Home Kitchen" },
            "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            999999
        ),
        new Product(
            new Guid("93170c85-7795-489c-8e8f-7dcf3b4f4188"),
            "Panasonic Lumix",
            new List<string> { "Camera" },
            "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            1234
        )
    };

}