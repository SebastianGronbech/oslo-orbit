namespace OsloOrbit.Domain.Forum;

public interface ITopicRepository
{
    Task<Topic?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Topic topic, CancellationToken cancellationToken = default);
}