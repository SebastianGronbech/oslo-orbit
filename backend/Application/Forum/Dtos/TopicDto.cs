namespace OsloOrbit.Application.Forum;

public record TopicDto(
    Guid Id,
    string Title,
    List<PostDto> Posts
);