using ProductsApi.Domain;

namespace ProductsApi.Adapters;

public interface IProductAdapter
{
    Task<IQueryable<Product>> GetProductsAsync();
}
