using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;

namespace Catalog.API.Products.CreateProduct
{
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                Image = command.Image,
                Price = command.Price
            };

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            
            return new CreateProductResult(product.Id);
        }
    }
    public record CreateProductCommand(string Name, List<string> Category, string Description, string Image, decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
}
