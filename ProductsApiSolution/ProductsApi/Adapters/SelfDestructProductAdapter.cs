using ProductsApi.Domain;

namespace ProductsApi.Adapters;

public class SelfDestructProductAdapter : IProductAdapter
{
    public Task<IQueryable<Product>> GetProductsAsync()
    {
        throw new NotImplementedException();
    }
}
