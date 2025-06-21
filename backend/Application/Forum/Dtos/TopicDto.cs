namespace OsloOrbit.Application.Forum;

public record TopicDto(
    Guid Id,
    string Title,
    Guid CreatorId,
    List<PostDto> Posts
);