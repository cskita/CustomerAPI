using Microsoft.Extensions.DependencyInjection;
using CustomerAPI.Core.Interface.Repository.City;
using CustomerAPI.Infra.Data.Repository.City;
using CustomerAPI.Core.Interface.Repository.Customer;
using CustomerAPI.Infra.Data.Repository.Customer;
using CustomerAPI.Core.Interface.Repository.Classification;
using CustomerAPI.Infra.Data.Repository.Classification;
using CustomerAPI.Core.Interface.Repository.Gender;
using CustomerAPI.Infra.Data.Repository.Region;
using CustomerAPI.Core.Interface.Repository.Region;
using CustomerAPI.Infra.Data.Repository.Gender;
using CustomerAPI.Core.Interface.Repository.User;
using CustomerAPI.Infra.Data.Repository.User;

namespace CustomerAPI.Infra.CrossCutting.IOC
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IClassificationRepository, ClassificationRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserSysRepository, UserSysRepository>();
        }
    }
}
