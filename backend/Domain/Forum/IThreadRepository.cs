namespace OsloOrbit.Domain.Forum;

public interface IThreadRepository
{
    Task<Thread?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}