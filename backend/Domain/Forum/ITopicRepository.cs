namespace OsloOrbit.Domain.Forum;

public interface ITopicRepository
{
    Task<Topic?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Topic topic);
}