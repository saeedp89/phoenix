using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.UI.Data;
using Phoenix.UI.Data.Repositories;
using Phoenix.UI.Forms;
using Phoenix.UI.Models;
using Phoenix.UI.Services;

namespace Phoenix.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = ConfigureServices();

            ManageDataSource(services);

            ApplicationConfiguration.Initialize();
            Application.Run(new UserCommentsForm(services.GetRequiredService<IUserCommentService>()));
            //Application.Run(new CommentsForm(services.GetRequiredService<IUserCommentService>()));
        }


        private static void ManageDataSource(IServiceProvider services)
        {
            using var serviceScope = services.CreateScope();
            var db = serviceScope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
            db.Database.EnsureCreated();
            db.Database.Migrate();
            //
            //var allData = db.Comments.Take(100).ToList();
            //foreach (var userComment in allData)
            //{
            //    Console.WriteLine(userComment.Comment);
            //}
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<PhoenixDbContext>();
            services.AddTransient<IUserCommentRepository, UserCommentRepository>();
            services.AddTransient<IUserCommentService, UserCommentService>();
            services.AddHttpClient("parspack",
                client => { client.BaseAddress = new Uri("http://tasks.cloudsite.ir"); });
            return services.BuildServiceProvider();
        }

        public static void PopulateDbFromServer(IServiceProvider services)
        {
            var serviceScope = services.CreateScope();
            var factory = serviceScope.ServiceProvider.GetRequiredService<IHttpClientFactory>();
            var httpClient = factory.CreateClient("parspack");
            var db = serviceScope.ServiceProvider.GetRequiredService<PhoenixDbContext>();
            db.Database.EnsureCreated();
            db.Database.Migrate();

            var commentsDto = httpClient
                .GetFromJsonAsync<IEnumerable<CommentDto>>("/api").Result;

            if (db.Comments.Any())
            {
                db.Comments.RemoveRange(db.Comments);
                db.SaveChanges();
            }

            foreach (var commentDto in commentsDto)
            {
                UserComment comment = commentDto.ToUserComment();
                db.Comments.Add(comment);
            }

            db.SaveChanges();
        }
    }
}