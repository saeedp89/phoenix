using Phoenix.Infrastructure.Models;
using Phoenix.Infrastructure.Models.Entities;

namespace Phoenix.Infrastructure.Abstractions;

public interface IUserCommentRepository
{
    Task TruncateAsync();
    Task<IEnumerable<UserComment>> SearchAsync(int count = 5, int skip = 0, string searchTerm = "");
    Task<int> CountAsync();
    Task AddRangeAsync(IEnumerable<UserComment> comments);
}