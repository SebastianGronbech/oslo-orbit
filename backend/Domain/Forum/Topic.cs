using OsloOrbit.SharedKernel;

namespace OsloOrbit.Domain.Forum;

public sealed class Topic : BaseEntity
{
    public Guid Id { get; private init; }
    public string Title { get; private set; }

    private readonly List<Post> _posts = [];
    public IReadOnlyList<Post> Posts => _posts;

    private Topic(Guid id, string title)
    {
        Id = id;
        Title = title;
    }

    public static Topic Create(Guid id, string title)
    {
        return new Topic(id, title);
    }
}