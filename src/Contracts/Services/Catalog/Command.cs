using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Catalog;

public class Command
{
    public record CreateProduct(string Name, string Description, decimal Price);
    public record UpdateProduct(int Id, string Name, string Description, decimal Price);
    public record DeleteProductById(int Id);
    public record GetProductById(int Id);
    public record GetProducts;
}
