using Phoenix.Infrastructure.Models.DataTransferObjects;

namespace Phoenix.Infrastructure.Abstractions;

public interface IUserCommentService
{
    IEnumerable<CommentDto> GetCommentsFromApi(string url);
    IEnumerable<CommentDto> GetCommentsFromDb(int pageSize = 5, int pageIndex = 1, string searchTerm = "");
   
    string PostData(CommentDto commentDto);
    void ClearLocalTable();
    void SynchronizeDatabaseWithServer();
}