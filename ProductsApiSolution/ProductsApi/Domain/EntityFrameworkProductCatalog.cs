using ProductsApi.Adapters;

namespace ProductsApi.Domain;

public class EntityFrameworkProductCatalog : IProductAdapter
{
    public Task<IQueryable<Product>> GetProductsAsync()
    {
        throw new NotImplementedException();
    }
}
