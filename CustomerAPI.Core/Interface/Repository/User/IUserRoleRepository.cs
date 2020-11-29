using System.Collections.Generic;
using CustomerAPI.Core.Model.User;

namespace CustomerAPI.Core.Interface.Repository.User
{
    public interface IUserRoleRepository
    {
        List<UserRole> Get();
        UserRole GetById(int id);
    }
}
