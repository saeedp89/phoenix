using Phoenix.Infrastructure.Models.DataTransferObjects;

namespace Phoenix.Infrastructure.Abstractions;

public interface IUserCommentService
{
    Task<IEnumerable<CommentDto>> GetCommentsFromApiAsync(string url);
    Task<IEnumerable<CommentDto>> GetCommentsFromDbAsync(int pageSize = 5, int pageIndex = 1, string searchTerm = "");
   
    Task<string> PostDataAsync(CommentDto commentDto);
    Task ClearLocalTableAsync();
    Task SynchronizeDatabaseWithServerAsync();
}