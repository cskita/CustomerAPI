using CustomerAPI.Application.DTO.User.ViewModel;
using Swashbuckle.AspNetCore.Annotations;

namespace CustomerAPI.Application.DTO.Authorization.ViewModel
{
    public class AuthorizationViewModel
    {
        [SwaggerSchema(Description = "Token of logged user")]
        public string Token { get; set; }

        [SwaggerSchema(Description = "Refresh token of logged user")]
        public string RefreshToken { get; set; }

        [SwaggerSchema(Description = "User data")]
        public UserViewModel User { get; set; }
    }
}
