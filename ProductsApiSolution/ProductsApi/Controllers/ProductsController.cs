using Microsoft.AspNetCore.Mvc;
using ProductsApi.Adapters;
using ProductsApi.Domain;
using ProductsApi.Models;

namespace ProductsApi.Controllers;

public class ProductsController : ControllerBase
{

    private readonly ProductCatalog _productCatalog;
    private readonly IOnCallDeveloperApiAdapter _onCallAdapter;
    public ProductsController(ProductCatalog productCatalog, IOnCallDeveloperApiAdapter onCallAdapter)
    {
        _productCatalog = productCatalog;
        _onCallAdapter = onCallAdapter;
    }

    [HttpGet("products")]
    public async Task<ActionResult> GetProducts()
    {
        try
        {
            CollectionResult<ProductSummaryItemResponse> response = await _productCatalog.GetAllAsync();
            return Ok(response);
        }
        catch (Exception)
        {
            var dev = await _onCallAdapter.GetOnCallDeveloperAsync();

            var errorResponse = new ErrorResponseMessage
            {
                Message = "That done blewed up!",
                StatusCode = 500,
                ForHelpContact = new HelpDeskInfo { 
                    Name = dev.name, 
                    Phone = dev.phone, 
                    Email = dev.email }
            };
            // Call the API and get the oncall developer...
            return StatusCode(500, errorResponse);
        }
    }
}
