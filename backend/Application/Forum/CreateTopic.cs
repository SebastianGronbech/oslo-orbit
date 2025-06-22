using FluentResults;
using MediatR;
using OsloOrbit.Domain.Forum;
using OsloOrbit.SharedKernel;

namespace OsloOrbit.Application.Forum;

public class CreateTopic
{
    public record Command(string Title, Guid CreatorId, string InitialPostContent) : IRequest<Result<Guid>>;

    public class Handler : IRequestHandler<Command, Result<Guid>>
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(ITopicRepository topicRepository, IUnitOfWork unitOfWork)
        {
            _topicRepository = topicRepository ?? throw new ArgumentNullException(nameof(topicRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Result<Guid>> Handle(Command request, CancellationToken cancellationToken)
        {
            var topic = Topic.Create(Guid.CreateVersion7(), request.Title, request.CreatorId, request.InitialPostContent);
            _topicRepository.Add(topic);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok(topic.Id);
        }
    }
}