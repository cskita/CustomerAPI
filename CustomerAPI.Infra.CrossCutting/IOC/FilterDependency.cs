using CustomerAPI.Framework.Filter;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerAPI.Infra.CrossCutting.IOC
{
    public static class FilterDependency
    {
        public static void AddExceptionFilterDependency(this IServiceCollection services)
        {
            services.AddMvc(o => o.Filters.Add(new ExceptionFilter()));
            services.AddMvc(o => o.Filters.Add(new ActionFilter()));
        }
    }
}
