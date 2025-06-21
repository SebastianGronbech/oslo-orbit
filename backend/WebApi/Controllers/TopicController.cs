using MediatR;
using Microsoft.AspNetCore.Mvc;
using OsloOrbit.Application.Forum;

namespace OsloOrbit.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TopicController : ControllerBase
{
    private readonly ISender _mediator;

    public TopicController(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> CreateTopic([FromBody] CreateTopic.Command command, CancellationToken cancellationToken)
    {
        if (command == null)
        {
            return BadRequest("Command cannot be null.");
        }

        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }

        return CreatedAtAction(nameof(GetTopicById), new { id = result.Value }, result.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTopicById(Guid id, CancellationToken cancellationToken)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Invalid topic ID.");
        }

        var result = await _mediator.Send(new GetById.Query(id), cancellationToken);

        if (result.IsFailed)
        {
            return NotFound(result.Errors);
        }

        return Ok(result.Value);
    }
}