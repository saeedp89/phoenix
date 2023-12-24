using Microsoft.EntityFrameworkCore;
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


    public async Task TruncateAsync()
    {
        using var scope = _provider.CreateScope();
        var context=scope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
        
        context.Comments.RemoveRange(context.Comments.ToList());
        await context.SaveChangesAsync();
    }


    public async Task<IEnumerable<UserComment>> SearchAsync(int count = 5, int skip = 0, string searchTerm = "")
    {
        using var serviceScope = _provider.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
        var query = context.Comments.OrderByDescending(x=>x.Id).AsQueryable();
        if (!string.IsNullOrWhiteSpace(searchTerm))
            query = query.Where(x => x.Name.Contains(searchTerm) || x.Comment.Contains(searchTerm));
        return await query.Skip(skip).Take(count).ToListAsync();
    }

    public async Task<int> CountAsync()
    {
        using var serviceScope = _provider.CreateScope();
         var context = serviceScope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
         return await context.Comments.CountAsync();
    }


    public async Task AddRangeAsync(IEnumerable<UserComment> comments)
    {
        using var serviceScope = _provider.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
        await context.Comments.AddRangeAsync(comments);

        await context.SaveChangesAsync();
    }
}