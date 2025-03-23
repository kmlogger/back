using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CreateRequest = Application.UseCases.Log.Hot.Create.Request;
using ReadAllTodayRequest = Application.UseCases.Log.Hot.Read.ReadByApp.Request;
using ReadByApp =  Application.UseCases.Log.Hot.Read.ReadByApp.Request;
using ReadById =  Application.UseCases.Log.Hot.Read.ReadById.Request;

using ReadByAppCold =  Application.UseCases.Log.Read.Cold.ReadByApp.Request;
using ReadByIdCold =  Application.UseCases.Log.Cold.Read.ReadById.Request;
using ReadByInterval =  Application.UseCases.Log.Cold.Read.ReadByInterval.Request;


namespace Presentation.Controllers;

[ApiController]
[Route("logs")]
public class LogController(IMediator mediator) : ControllerBase
{
    #region  HOT

    [HttpPost("Create")]
    public async Task<IActionResult> CreateLog([FromBody] CreateRequest request, CancellationToken cancellationToken)
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

    [HttpGet("ReadAllToday")]
    public async Task<IActionResult> ReadAllToday([FromQuery] ReadAllTodayRequest request, CancellationToken cancellationToken)
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

    [HttpGet("ReadByApp")]
    public async Task<IActionResult> ReadByApp([FromQuery] ReadByApp request, CancellationToken cancellationToken)
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

    [HttpGet("ReadById")]
    public async Task<IActionResult> ReadById([FromQuery] ReadById request, CancellationToken cancellationToken)
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
    #endregion
    
    #region COLD

    [HttpGet("Cold/ReadByApp")]
    public async Task<IActionResult> ReadByAppCold([FromQuery] ReadByAppCold request, CancellationToken cancellationToken)
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

    [HttpGet("Cold/ReadById")]
    public async Task<IActionResult> ReadById([FromQuery] ReadByIdCold request, CancellationToken cancellationToken)
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

    [HttpGet("Cold/ReadByInterval")]
    public async Task<IActionResult> ReadByInterval([FromQuery] ReadByInterval request, CancellationToken cancellationToken)
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
    #endregion
}
