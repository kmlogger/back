using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CreateRequest = Application.UseCases.Category.Create.Request;
using DeleteRequest =  Application.UseCases.Category.Delete.Request;
using ReadRequest =  Application.UseCases.Category.Read.RealAll.Request;

namespace Presentation.Controllers;

[ApiController]
[Route("category")]
public class CategoryController(IMediator mediator) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateRequest request, CancellationToken cancellationToken)
    {
        if(!ModelState.IsValid) return BadRequest();
        try
        {
            var response = await mediator.Send(request, cancellationToken);
            return StatusCode(response.statuscode, new {response.notifications, response.message});
        }
        catch(Exception e)
        {
            return StatusCode(500 , new {message = e.Message});
        }
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteCategory([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        if(!ModelState.IsValid) return BadRequest();
        try
        {
            var response = await mediator.Send(new DeleteRequest(id), cancellationToken);
            return StatusCode(response.statuscode, new {response.notifications, response.message});
        }
        catch(Exception e)
        {
            return StatusCode(500 , new {message = e.Message});
        }
    }

    [HttpGet("read")]
    public async Task<IActionResult> Read([FromQuery] int skip, [FromQuery] int take, CancellationToken cancellationToken)
    {
        if(!ModelState.IsValid) return BadRequest();
        try
        {
            var response = await mediator.Send(new ReadRequest(skip, take), cancellationToken);
            return StatusCode(response.statuscode, new {response.notifications, response.message});
        }
        catch(Exception e)
        {
            return StatusCode(500 , new {message = e.Message});
        }
    }
}
