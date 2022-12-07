using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.AppStart
{
    public static class NetCoreDiSetupExtensions
    {
        public static void RegisterSpiderDi(this IServiceCollection services)
        {
            services.RegisterAssemblyPublicNonGenericClasses()
                .AsPublicImplementedInterfaces();
        }
    }
}
