using Microsoft.Extensions.DependencyInjection;
using Phoenix.UI.Models;

namespace Phoenix.UI.Data.Repositories;

public class UserCommentRepository : IUserCommentRepository
{
    private readonly IServiceProvider _provider;

    public UserCommentRepository(IServiceProvider provider)
    {
        _provider = provider;
    }

    public UserComment GetById(long id)
    {
        using var scope = _provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
        var comment = context.Comments.FirstOrDefault(x => x.Id == id);
        return comment ?? throw new Exception($"No user found with Id: {id}");
    }

    public void ClearTable()
    {
        using var scope=_provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
        if (context.Comments.Any())
        {
            context.Comments.RemoveRange(context.Comments);
            context.SaveChanges();
        }
        
    }


    public IEnumerable<UserComment> GetByName(string name)
    {
        using var serviceScope = _provider.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
        return context.Comments.Where(x => x.Name.Contains(name)).ToList();
    }

    public IEnumerable<UserComment> GetAllDescending(int count)
    {
        using var serviceScope = _provider.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
        return context.Comments.OrderByDescending(x => x.Id).Take(count).ToList();
    }

    public IEnumerable<UserComment> Take(int count = 5, int skip = 0, string searchTerm = "")
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

    public void Add(UserComment comment)
    {
        using var serviceScope = _provider.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
        context.Comments.Add(comment);
        context.SaveChanges();
    }

    public void AddRange(IEnumerable<UserComment> comments)
    {
        using var serviceScope = _provider.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
        context.Comments.AddRange(comments);
        context.SaveChanges();
    }
}