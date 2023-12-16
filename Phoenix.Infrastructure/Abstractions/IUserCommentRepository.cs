using Phoenix.Infrastructure.Models;
using Phoenix.Infrastructure.Models.Entities;

namespace Phoenix.Infrastructure.Abstractions;

public interface IUserCommentRepository
{
    void ClearTable();
    IEnumerable<UserComment> Search(int count = 5, int skip = 0, string searchTerm = "");
    int Count();
    void AddRange(IEnumerable<UserComment> comments);
}