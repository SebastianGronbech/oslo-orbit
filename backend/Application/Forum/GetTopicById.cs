using FluentResults;
using MediatR;
using OsloOrbit.Domain.Forum;

namespace OsloOrbit.Application.Forum;

public class GetTopicById
{
    public record Query(Guid Id) : IRequest<Result<TopicDto>>;

    public class Handler : IRequestHandler<Query, Result<TopicDto>>
    {
        private readonly ITopicRepository _topicRepository;

        public Handler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<Result<TopicDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var topic = await _topicRepository.GetByIdAsync(request.Id, cancellationToken);
            if (topic == null)
            {
                return Result.Fail($"Topic with ID {request.Id} not found.");
            }

            return Result.Ok(new TopicDto(
                topic.Id,
                topic.Title,
                topic.CreatorId,
                [.. topic.Posts.Select(p => new PostDto(
                    p.Id,
                    p.AuthorId,
                    p.Content,
                    [.. p.Comments.Select(c => new CommentDto(c.Id, c.AuthorId, c.Content))]
                ))]
            ));
        }
    }
}