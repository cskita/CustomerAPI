using System;
using System.Collections.Generic;
using System.Text;
using CustomerAPI.Framework.Domain;
using CustomerAPI.Core.Model.User;
using CustomerAPI.Core.Interface.Service.User;
using CustomerAPI.Core.Interface.Repository.User;

namespace CustomerAPI.Service.User
{
    public class UserSysService : IUserSysService
    {
        private readonly IUserSysRepository _userSysRepository;

        public UserSysService(IUserSysRepository userSysRepository)
        {
            _userSysRepository = userSysRepository;
        }

        public BaseResult<List<UserSys>> Get()
        {
            try
            {
                var users = _userSysRepository.Get();

                return BaseResult<List<UserSys>>.OK(users);
            }
            catch (Exception e)
            {
                return BaseResult<List<UserSys>>.NotOK(e.Message);
            }
        }

        public BaseResult<UserSys> GetById(int id)
        {
            try
            {
                var user = _userSysRepository.GetById(id);

                return BaseResult<UserSys>.OK(user);
            }
            catch (Exception e)
            {
                return BaseResult<UserSys>.NotOK(e.Message);
            }
        }

        public BaseResult<UserSys> GetByIdWithRole(int id)
        {
            try
            {
                var user = _userSysRepository.GetByIdWithRole(id);

                return BaseResult<UserSys>.OK(user);
            }
            catch (Exception e)
            {
                return BaseResult<UserSys>.NotOK(e.Message);
            }
        }
    }
}
