using OsloOrbit.SharedKernel;

namespace OsloOrbit.Domain.Forum;

public sealed class Thread : BaseEntity
{
    public Guid Id { get; private init; }
    public string Title { get; private set; }

    private readonly List<Post> _posts = [];
    public IReadOnlyList<Post> Posts => _posts;

    private Thread(Guid id, string title)
    {
        Id = id;
        Title = title;
    }

    public static Thread Create(Guid id, string title)
    {
        return new Thread(id, title);
    }
}