using FluentResults;
using MediatR;
using OsloOrbit.Domain.Forum;

namespace OsloOrbit.Application.Forum;

public class CreateTopic
{
    public record Command(string Title, Guid CreatorId, string InitialPostContent) : IRequest<Result<Guid>>;

    public class Handler : IRequestHandler<Command, Result<Guid>>
    {
        private readonly ITopicRepository _topicRepository;

        public Handler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<Result<Guid>> Handle(Command request, CancellationToken cancellationToken)
        {
            var topic = Topic.Create(Guid.CreateVersion7(), request.Title, request.CreatorId, request.InitialPostContent);
            await _topicRepository.AddAsync(topic, cancellationToken);

            return Result.Ok(topic.Id);
        }
    }
}