using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Spider.AppStart
{
    public static class SwaggerSetUp
    {
        public static void AddSwaggerSetUp(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var ApiName = "Webapi.Core";

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    // {ApiName} 定义成全局变量，方便修改
                    Version = "V1",
                    Title = $"{ApiName} 接口文档",
                    Description = $"{ApiName} HTTP API V1",

                });
                c.OrderActionsBy(o => o.RelativePath);
            });
        }
    }
}
