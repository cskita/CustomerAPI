using CustomerAPI.Framework.Domain;
using System.Collections.Generic;
using CustomerAPI.Core.Model.User;

namespace CustomerAPI.Core.Interface.Service.User
{
    public interface IUserSysService
    {
        BaseResult<List<UserSys>> Get();
        BaseResult<UserSys> GetById(int id);
        BaseResult<UserSys> GetByIdWithRole(int id);
    }
}
