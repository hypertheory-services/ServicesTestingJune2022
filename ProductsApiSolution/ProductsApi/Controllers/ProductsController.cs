using Microsoft.AspNetCore.Mvc;
using ProductsApi.Domain;
using ProductsApi.Models;

namespace ProductsApi.Controllers;

public class ProductsController : ControllerBase
{

    private readonly ProductCatalog _productCatalog;

    public ProductsController(ProductCatalog productCatalog)
    {
        _productCatalog = productCatalog;
    }

    [HttpGet("products")]
    public async Task<ActionResult> GetProducts()
    {
        CollectionResult<ProductSummaryItemResponse> response = await _productCatalog.GetAllAsync();
        return Ok(response);
    }
}
