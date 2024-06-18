namespace Contracts.Services.Catalog;

public class Http
{
    public class Request
    {
        public record CreateProduct(string Name, List<string> Category, string Description, string ImageFile, decimal Price);

    }
    public class Response
    {
        public record CreateProduct(Guid Id);
    }
}
