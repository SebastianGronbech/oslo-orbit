using FluentResults;
using MediatR;
using OsloOrbit.Domain.Forum;
using OsloOrbit.SharedKernel;

namespace OsloOrbit.Application.Forum;

public class AddComment
{
    public record Command(Guid TopicId, Guid PostId, Guid AuthorId, string Content) : IRequest<Result<Guid>>;

    public class Handler : IRequestHandler<Command, Result<Guid>>
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IPostRepository postRepository, IUnitOfWork unitOfWork, ITopicRepository topicRepository)
        {
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _topicRepository = topicRepository ?? throw new ArgumentNullException(nameof(topicRepository));
        }

        public async Task<Result<Guid>> Handle(Command request, CancellationToken cancellationToken)
        {
            var topic = await _topicRepository.GetByIdAsync(request.TopicId, cancellationToken);
            if (topic is null)
            {
                return Result.Fail(new Error("Topic not found."));
            }

            topic.AddCommentToPost(request.PostId, request.AuthorId, request.Content);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}