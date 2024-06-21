namespace Contracts.DataTransferObjects;
public record Product(Guid Id, string Name, List<string> Category, string Description, long Price);
public record CreateProduct(string Name, string Description, List<string> Category, long Price);