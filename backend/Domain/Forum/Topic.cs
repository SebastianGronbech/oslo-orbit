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

        topic.AddPost(creatorId, initialPostContent);

        return topic;
    }

    public void AddPost(Guid authorId, string content)
    {
        var post = Post.Create(Guid.CreateVersion7(), authorId, content);
        _posts.Add(post);
    }

    public void AddCommentToPost(Guid postId, Guid authorId, string content)
    {
        var post = _posts.FirstOrDefault(p => p.Id == postId);
        if (post is null)
        {
            throw new InvalidOperationException($"Post with ID {postId} not found in topic {Id}.");
        }

        post.AddComment(authorId, content);
    }
}