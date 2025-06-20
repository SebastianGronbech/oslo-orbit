namespace OsloOrbit.Application.Forum;

public record CommentDto(
    Guid Id,
    Guid AuthorId,
    string Content);