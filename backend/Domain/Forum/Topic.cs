using OsloOrbit.SharedKernel;

namespace OsloOrbit.Domain.Forum;

public sealed class Topic : BaseEntity
{
    public Guid Id { get; private init; }
    public string Title { get; private set; }
    public Guid CreatorId { get; private set; }

    private readonly List<Post> _posts = [];
    public IReadOnlyList<Post> Posts => _posts;

    private Topic(Guid id, string title, Guid creatorId)
    {
        Id = id;
        Title = title;
        CreatorId = creatorId;
    }

    public static Topic Create(Guid id, string title, Guid creatorId, string initialPostContent)
    {
        var topic = new Topic(id, title, creatorId);

        var post = Post.Create(Guid.CreateVersion7(), creatorId, initialPostContent);
        topic._posts.Add(post);

        return topic;
    }
}