using Microsoft.Extensions.Http;
using Phoenix.UI.Models;

namespace Phoenix.UI.Services;

public interface IUserCommentService
{
    IEnumerable<CommentDto> GetCommentsFromApi(string url);
    IEnumerable<CommentDto> GetCommentsFromDb(int pageSize = 5, int pageIndex = 1, string searchTerm = "");
   
    string PostData(CommentDto commentDto);
    void ClearLocalTable();
    void SynchronizeDatabaseWithServer();
}