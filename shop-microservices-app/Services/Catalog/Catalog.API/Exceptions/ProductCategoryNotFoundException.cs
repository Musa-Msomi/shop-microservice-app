namespace Catalog.API.Exceptions
{
    public class ProductCategoryNotFoundException : Exception
    {
        public ProductCategoryNotFoundException() : base("Product category not found")
        {
        }
    }
}
