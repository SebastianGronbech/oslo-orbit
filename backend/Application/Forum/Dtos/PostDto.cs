namespace OsloOrbit.Application.Forum;

public record PostDto(
    Guid Id,
    Guid AuthorId,
    string Content,
    List<CommentDto> Comments
);