using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Infrastructure.Abstractions;
using Phoenix.Infrastructure.Data;
using Phoenix.Infrastructure.Data.Repositories;
using Phoenix.Infrastructure.Extensions;
using Phoenix.Infrastructure.Models.DataTransferObjects;
using Phoenix.Infrastructure.Models.Entities;
using Phoenix.Infrastructure.Services;
using Phoenix.UI.Forms;

namespace Phoenix.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var startup = new Startup();
            var services = startup.ConfigureServices();
            ManageDataMigration(services);
            var userCommentService = services.GetRequiredService<IUserCommentService>();
            
            ApplicationConfiguration.Initialize();
            
            Application.Run(new UserCommentsForm(userCommentService));
        }

        private static void ManageDataMigration(IServiceProvider services)
        {
            var context = services.GetRequiredService<PhoenixDbContext>();
            context.Database.EnsureCreated();
            context.Database.Migrate();
        }
    }
}