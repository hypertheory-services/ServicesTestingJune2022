using Microsoft.AspNetCore.Mvc;

namespace ProductsApi.Controllers;

public class ProductsController : ControllerBase
{
    [HttpGet("products")]
    public async Task<ActionResult> GetProducts()
    {
        return Ok();
    }
}
