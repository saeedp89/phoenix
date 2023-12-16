using Microsoft.Extensions.DependencyInjection;
using Phoenix.Infrastructure.Abstractions;
using Phoenix.Infrastructure.Models.Entities;

namespace Phoenix.Infrastructure.Data.Repositories;

public class UserCommentRepository : IUserCommentRepository
{
    private readonly IServiceProvider _provider;

    public UserCommentRepository(IServiceProvider provider)
    {
        _provider = provider;
  
    }


    public void ClearTable()
    {
        using var scope = _provider.CreateScope();
        var context=scope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
        
        context.Comments.RemoveRange(context.Comments.ToList());
        context.SaveChanges();
    }


    public IEnumerable<UserComment> Search(int count = 5, int skip = 0, string searchTerm = "")
    {
        using var serviceScope = _provider.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
        var query = context.Comments.AsQueryable();
        if (!string.IsNullOrWhiteSpace(searchTerm))
            query = query.Where(x => x.Name.Contains(searchTerm) || x.Comment.Contains(searchTerm));
        return query.Skip(skip).Take(count).ToList();
    }

    public int Count()
    {
        using var serviceScope = _provider.CreateScope();
         var context = serviceScope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
         return context.Comments.Count();
    }


    public void AddRange(IEnumerable<UserComment> comments)
    {
        using var serviceScope = _provider.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
        context.Comments.AddRange(comments);

        context.SaveChanges();
    }
}