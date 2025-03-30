using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CreateRequest = Application.UseCases.App.Create.Request;
using ReadAllRequest = Application.UseCases.App.Read.ReadAll.Request;

namespace Presentation.Controllers;

[ApiController]
[Route("app")]
[Authorize]
public class AppController(IMediator mediator) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateApp([FromBody] CreateRequest request, CancellationToken cancellationToken)
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

    [HttpGet("read")]
    public async Task<IActionResult> Read([FromQuery] int skip, [FromQuery] int take, CancellationToken cancellationToken)
    {
        if(!ModelState.IsValid) return BadRequest();
        try
        {
            var response = await mediator.Send(new ReadAllRequest(skip, take), cancellationToken);
            return StatusCode(response.statuscode, new {response.notifications, response.message});
        }
        catch(Exception e)
        {
            return StatusCode(500 , new {message = e.Message});
        }
    }
}
