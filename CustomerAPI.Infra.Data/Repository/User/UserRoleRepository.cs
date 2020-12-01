using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerAPI.Infra.Data.Context;
using CustomerAPI.Core.Model.User;
using CustomerAPI.Core.Interface.Repository.User;
using CustomerAPI.Framework.GeneralException;

namespace CustomerAPI.Infra.Data.Repository.User
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IQueryable<UserRole> GetQuery()
        {
            return _unitOfWork.Query<UserRole>();
        }

        public List<UserRole> Get()
        {
            return GetQuery().AsNoTracking().ToList();
        }

        public UserRole GetById(int id)
        {
            var userRole = GetQuery().AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (userRole == null)
                throw new NotFoundException("User role not found");

            return userRole;
        }
    }
}
