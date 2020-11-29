using System.Collections.Generic;
using CustomerAPI.Core.Model.User;

namespace CustomerAPI.Core.Interface.Repository.User
{
    public interface IUserSysRepository
    {
        List<UserSys> Get();
        UserSys GetById(int id);
        UserSys GetByLoginAndPassword(UserLogin userLogin);
        UserSys GetByIdWithRole(int id);
    }
}
