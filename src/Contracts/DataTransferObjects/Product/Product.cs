namespace Contracts.DataTransferObjects;
public record Product(int Id, string Name, List<string> Category, string Description, long Price);