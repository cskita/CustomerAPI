using CustomerAPI.Core.Model.Authorization;
using CustomerAPI.Core.Model.User;
using CustomerAPI.Framework.Domain;

namespace CustomerAPI.Core.Interface.Service.Authorization
{
    public interface IAuthorizationService
    {
        BaseResult<AuthorizationToken> Authenticate(UserLogin userLogin);
    }
}
