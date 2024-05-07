using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;
using QuickOut.Application.Products.Commands;
using QuickOut.Application.Products.Queries;
using QuickOut.Infrastructure.Common;
using QuickOut.Library;

namespace QuickOut.Controllers;

[ApiController]
[Route("product")]
public class ProductController : VicthorController
{
    public ProductController(VicthotMediator commands, JwtTokenManager jwtTokenManager) : base(commands,
        jwtTokenManager)
    {
    }

    [HttpGet("read")]
    public async Task<IActionResult> ReadProducts(
        [FromServices] ReadProductsQueryHandler query,
        [FromQuery] ReadProductsParams parameters)
    {
        try
        {
            return Ok(await query.Handle(parameters));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddProduct(AddProductCommand command)
    {
        try
        {
            Result<Guid> result = await commands.Execute(command);

            if (!result.Succeeded)
            {
                return BadRequest(result.Messages);
            }

            return Ok(result.Data);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}