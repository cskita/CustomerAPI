using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerAPI.Infra.Data.Context;
using CustomerAPI.Core.Model.User;
using CustomerAPI.Core.Interface.Repository.User;
using CustomerAPI.Framework.GeneralException;

namespace CustomerAPI.Infra.Data.Repository.User
{
    public class UserSysRepository : IUserSysRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserSysRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IQueryable<UserSys> GetQuery()
        {
            return _unitOfWork.Query<UserSys>();
        }

        public List<UserSys> Get()
        {
            return GetQuery().AsNoTracking().ToList();
        }

        public UserSys GetById(int id)
        {
            var user = GetQuery().AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (user == null)
                throw new NotFoundException("User not found");

            return user;
        }

        public UserSys GetByLoginAndPassword(UserLogin userLogin)
        {
            var user = GetQuery().AsNoTracking()
                .Include(r => r.UserRole).AsNoTracking()
                .FirstOrDefault(x => x.Email == userLogin.Email && x.Password == userLogin.Password);

            return user;
        }

        public UserSys GetByIdWithRole(int id)
        {
            var user = GetQuery()
                .Include(r => r.UserRole).AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (user == null)
                throw new NotFoundException("User not found");

            return user;
        }
    }
}
