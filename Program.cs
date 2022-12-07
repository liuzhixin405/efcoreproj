using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spider.AppStart;
using Spider.BackService;
using Spider.DataLayer;
using Spider.DataLayer.Context;
using Spider.DbContextFactory;
using System.Threading.Tasks;

namespace Spider
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.RegisterSpiderDi();
            builder.Services.AddSwaggerSetUp();
            builder.Services.AddDbContext<NewsLetterContext>();
            builder.Services.SetupDatabase();
            builder.Services.AddHostedService<BackNewsLetterService>();

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", "WebApi.Core V1");
                c.RoutePrefix = "ApiDoc";
            });
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });

            await app.RunAsync();
        }
    }
}