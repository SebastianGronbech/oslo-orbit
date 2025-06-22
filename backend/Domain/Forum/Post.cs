using OsloOrbit.SharedKernel;

namespace OsloOrbit.Domain.Forum;

public sealed class Post : BaseEntity
{
    public Guid Id { get; private init; }
    public Guid AuthorId { get; private set; }
    public string Content { get; private set; }
    private readonly List<Comment> _comments = [];
    public IReadOnlyList<Comment> Comments => _comments.AsReadOnly();

    private Post(Guid id, Guid authorId, string content)
    {
        Id = id;
        AuthorId = authorId;
        Content = content;
    }

    public static Post Create(Guid id, Guid authorId, string content)
    {
        return new Post(id, authorId, content);
    }

    public void AddComment(Guid authorId, string content)
    {
        var comment = Comment.Create(Guid.CreateVersion7(), authorId, content);
        _comments.Add(comment);
    }
}