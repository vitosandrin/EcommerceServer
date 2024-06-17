using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Catalog;

public class Command
{
    public record CreateProduct(string Name, string Description, List<string> Category, long Price);
    public record UpdateProduct(int Id, string Name, List<string> Category, string Description, long Price);
    public record DeleteProductById(int Id);
    public record GetProductById(int Id);
    public record GetProducts;
}
