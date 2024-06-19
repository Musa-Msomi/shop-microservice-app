using BuildingBlocks.CQRS;
using Catalog.API.Exceptions;
using Catalog.API.Models;
using Marten;

namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string Image, decimal Price) : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool IsUpdated);
    internal class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating product");
            var product = await session.LoadAsync<Product>(request.Id, cancellationToken);
            if (product is null)
            {
                throw new ProductNotFoundException();
            }
            product.Name = request.Name;
            product.Category = request.Category;
            product.Description = request.Description;
            product.Image = request.Image;
            product.Price = request.Price;

            session.Update(product);

            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
        }
    }

}
