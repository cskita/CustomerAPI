using System;
using System.Collections.Generic;
using System.Text;
using CustomerAPI.Framework.Domain;
using CustomerAPI.Core.Model.User;
using CustomerAPI.Core.Interface.Service.User;
using CustomerAPI.Core.Interface.Repository.User;

namespace CustomerAPI.Service.User
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public BaseResult<List<UserRole>> Get()
        {
            try
            {
                var userRoles = _userRoleRepository.Get();

                return BaseResult<List<UserRole>>.OK(userRoles);
            }
            catch (Exception e)
            {
                return BaseResult<List<UserRole>>.NotOK(e.Message);
            }
        }

        public BaseResult<UserRole> GetById(int id)
        {
            try
            {
                var userRole = _userRoleRepository.GetById(id);

                return BaseResult<UserRole>.OK(userRole);
            }
            catch (Exception e)
            {
                return BaseResult<UserRole>.NotOK(e.Message);
            }
        }
    }
}
