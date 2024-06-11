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

            // Save to database

            // Will return the Id of the newly created product once saved to the database. Placeholder id for now.
            return new CreateProductResult(Guid.NewGuid());
        }
    }
    public record CreateProductCommand(string Name, List<string> Category, string Description, string Image, decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
}
