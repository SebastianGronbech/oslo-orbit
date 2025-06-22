using OsloOrbit.Domain.Forum;

namespace OsloOrbit.Infrastructure.Persistence.Repository;

internal sealed class PostRepository : IPostRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PostRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void Add(Post post)
    {
        _dbContext.Posts.Add(post);
    }
}