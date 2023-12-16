using Phoenix.UI.Models;

namespace Phoenix.UI.Data.Repositories;

public interface IUserCommentRepository
{
    UserComment GetById(long id);
    void ClearTable();

    IEnumerable<UserComment> GetByName(string name);

    IEnumerable<UserComment> GetAllDescending(int count);

    IEnumerable<UserComment> Take(int count = 5, int skip= 0, string searchTerm = "");
    int Count();
    
    void Add(UserComment comment);
    void AddRange(IEnumerable<UserComment> comments);
}