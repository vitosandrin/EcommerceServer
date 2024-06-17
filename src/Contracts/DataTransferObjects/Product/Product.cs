namespace Contracts.DataTransferObjects;
public record Product(string Name, List<string> Category, string Description, long Price);