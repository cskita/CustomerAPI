using CustomerAPI.Framework.Domain;
using System.Collections.Generic;
using CustomerAPI.Core.Model.User;

namespace CustomerAPI.Core.Interface.Service.User
{
    public interface IUserRoleService
    {
        BaseResult<List<UserRole>> Get();

        BaseResult<UserRole> GetById(int id);
    }
}
