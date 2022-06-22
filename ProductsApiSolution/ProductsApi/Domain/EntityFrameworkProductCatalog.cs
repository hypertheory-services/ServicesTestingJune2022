using ProductsApi.Adapters;
using ProductsApi.Models;

namespace ProductsApi.Domain;

public class EntityFrameworkProductCatalog : IProductAdapter
{
    public Task<Product> AddProductAsync(CreateProductRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Product>> GetProductsAsync()
    {
        throw new NotImplementedException();
    }
}
