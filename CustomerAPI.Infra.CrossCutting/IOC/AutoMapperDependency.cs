using CustomerAPI.Infra.CrossCutting.Adapter;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerAPI.Infra.CrossCutting.IOC
{
    public static class AutoMapperDependency
    {
        public static void AddAutoMapperDependency(this IServiceCollection services)
        {
            services.AddSingleton(AutoMapperAdapter.ConfigureAutoMapper());
        }
    }
}
