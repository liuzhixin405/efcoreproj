using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reptile.AppStart;
using Reptile.BackService;
using Reptile.DataLayer;
using Reptile.DataLayer.Context;
using Reptile.DbContextFactory;
using System.Threading.Tasks;

namespace Reptile
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers()
                     .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressConsumesConstraintForFormFileParameters = true;
                options.SuppressInferBindingSourcesForParameters = true;
                options.SuppressModelStateInvalidFilter = true;
            }); ;
            builder.Services.RegisterReptileDi();
            builder.Services.AddSwaggerSetUp();
            builder.Services.AddDbContext<NewsLetterContext>();
            builder.Services.AddDbContext<CoinMarketCapContext>();
            builder.Services.SetupDatabase();
            builder.Services.AddHostedService<BackNewsLetterService>();
            builder.Services.AddHostedService<CoinMarketCapService>();

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