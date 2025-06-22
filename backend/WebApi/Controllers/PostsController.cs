using MediatR;
using Microsoft.AspNetCore.Mvc;
using OsloOrbit.Application.Forum;

namespace OsloOrbit.WebApi.Controllers;

[ApiController]
[Route("api/topics/{topicId}/[controller]")]
public class PostsController : ControllerBase
{
    private readonly ISender _mediator;
    public PostsController(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(Guid topicId,
        [FromBody] CreatePostRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreatePost.Command(topicId, request.AuthorId, request.Content);
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }

        // return CreatedAtAction(nameof(CreatePost), new { id = result.Value }, null);
        return Created();
    }
}

public sealed record CreatePostRequest(Guid AuthorId, string Content);