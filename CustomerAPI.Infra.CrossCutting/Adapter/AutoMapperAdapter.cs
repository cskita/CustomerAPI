using AutoMapper;
using CustomerAPI.Core.Model.City;
using CustomerAPI.Application.DTO.City.ViewModel;
using CustomerAPI.Core.Model.Customer;
using CustomerAPI.Application.DTO.Customer.ViewModel;
using CustomerAPI.Core.Model.Classification;
using CustomerAPI.Application.DTO.Classification.ViewModel;
using CustomerAPI.Core.Model.Gender;
using CustomerAPI.Application.DTO.Gender.ViewModel;
using CustomerAPI.Core.Model.Region;
using CustomerAPI.Application.DTO.Region.ViewModel;
using CustomerAPI.Application.DTO.Authorization.InputModel;
using CustomerAPI.Core.Model.User;
using CustomerAPI.Application.DTO.Authorization.ViewModel;
using CustomerAPI.Core.Model.Authorization;
using CustomerAPI.Application.DTO.User.ViewModel;

namespace CustomerAPI.Infra.CrossCutting.Adapter
{
    public class AutoMapperAdapter
    {
        public static IMapper ConfigureAutoMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                #region ViewModel
                cfg.CreateMap<City, CityViewModel>();
                cfg.CreateMap<Classification, ClassificationViewModel>();
                cfg.CreateMap<Customer, CustomerViewModel>();
                cfg.CreateMap<Gender, GenderViewModel>()
                    .ForMember(d => d.Name, o => o.MapFrom(x => x.Name.Trim()));
                cfg.CreateMap<Region, RegionViewModel>();
                cfg.CreateMap<UserSys, UserViewModel>()
                    .ForPath(d => d.IsAdmin, o => o.MapFrom(x => x.UserRole.IsAdmin));
                cfg.CreateMap<AuthorizationToken, AuthorizationViewModel>();
                #endregion

                #region InputModel
                cfg.CreateMap<AuthorizationInputModel, UserLogin>();
                #endregion
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
