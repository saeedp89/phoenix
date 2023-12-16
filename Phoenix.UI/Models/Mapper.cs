namespace Phoenix.UI.Models;

public static class Mapper
{
    public static CommentDto ToCommentDto(this UserComment userComment) => new CommentDto()
    {
        Id = userComment.Id,
        Date = userComment.Date,
        Comment = userComment.Comment,
        Name = userComment.Name
    };

    public static IEnumerable<CommentDto> ToCommentDto(this IEnumerable<UserComment> comments) =>
        comments.Select(ToCommentDto);


    public static UserComment ToUserComment(this CommentDto dto)
        =>
            new UserComment()
            {
                Name = dto.Name,
                Id = dto.Id,
                Comment = dto.Comment,
                Date = dto.Date
            };

    public static IEnumerable<UserComment> ToUserComment(this IEnumerable<CommentDto> dtos) =>
        dtos.Select(ToUserComment);
}