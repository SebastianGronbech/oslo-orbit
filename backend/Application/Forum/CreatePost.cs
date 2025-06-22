using FluentResults;
using MediatR;
using OsloOrbit.Domain.Forum;
using OsloOrbit.SharedKernel;

namespace OsloOrbit.Application.Forum;

public class CreatePost
{
    public record Command(Guid TopicId, Guid AuthorId, string Content) : IRequest<Result<Guid>>;

    public class Handler : IRequestHandler<Command, Result<Guid>>
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(ITopicRepository topicRepository, IUnitOfWork unitOfWork, IPostRepository postRepository)
        {
            _topicRepository = topicRepository ?? throw new ArgumentNullException(nameof(topicRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
        }

        public async Task<Result<Guid>> Handle(Command request, CancellationToken cancellationToken)
        {
            var topic = await _topicRepository.GetByIdAsync(request.TopicId, cancellationToken);
            if (topic is null)
            {
                return Result.Fail(new Error("Topic not found."));
            }

            topic.AddPost(request.AuthorId, request.Content);
            _postRepository.Add(topic.Posts[topic.Posts.Count - 1]);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok(topic.Id);
        }
    }
}