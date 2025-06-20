using Microsoft.EntityFrameworkCore;
using OsloOrbit.Domain.Forum;

namespace OsloOrbit.Infrastructure.Persistence.Repository;

internal sealed class TopicRepository : ITopicRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TopicRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public Task AddAsync(Topic topic, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Topic?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _dbContext.Topics
            .Include(t => t.Posts)
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}
