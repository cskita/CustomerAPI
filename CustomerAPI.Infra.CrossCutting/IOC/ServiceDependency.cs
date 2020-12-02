using Microsoft.Extensions.DependencyInjection;
using CustomerAPI.Service.City;
using CustomerAPI.Core.Interface.Service.City;
using CustomerAPI.Service.Classification;
using CustomerAPI.Core.Interface.Service.Classification;
using CustomerAPI.Service.Customer;
using CustomerAPI.Core.Interface.Service.Customer;
using CustomerAPI.Service.Gender;
using CustomerAPI.Core.Interface.Service.Gender;
using CustomerAPI.Service.Region;
using CustomerAPI.Core.Interface.Service.Region;
using CustomerAPI.Service.Seller;
using CustomerAPI.Core.Interface.Service.Seller;
using CustomerAPI.Service.User;
using CustomerAPI.Core.Interface.Service.User;
using CustomerAPI.Service.Authorization;
using CustomerAPI.Core.Interface.Service.Authorization;

namespace CustomerAPI.Infra.CrossCutting.IOC
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IClassificationService, ClassificationService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserSysService, UserSysService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
        }
    }
}
