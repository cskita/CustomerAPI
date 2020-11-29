using CustomerAPI.Core.Model.User;
namespace CustomerAPI.Core.Model.Authorization
{
    public class AuthorizationToken
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public UserSys User { get; set; }
    }
}
