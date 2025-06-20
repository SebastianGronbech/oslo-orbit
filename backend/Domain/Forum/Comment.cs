using OsloOrbit.SharedKernel;

namespace OsloOrbit.Domain.Forum;

public sealed class Comment : BaseEntity
{
    public Guid Id { get; private init; }
    public Guid AuthorId { get; private set; }
    public string Content { get; private set; }

    private Comment(Guid id, Guid authorId, string content)
    {
        Id = id;
        AuthorId = authorId;
        Content = content;
    }

    public static Comment Create(Guid id, Guid authorId, string content)
    {
        return new Comment(id, authorId, content);
    }
}