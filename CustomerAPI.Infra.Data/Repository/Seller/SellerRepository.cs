using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerAPI.Infra.Data.Context;
using CustomerAPI.Core.Model.User;
using CustomerAPI.Framework.GeneralException;
using CustomerAPI.Core.Interface.Repository.Seller;

namespace CustomerAPI.Infra.Data.Repository.Seller
{
    public class SellerRepository : ISellerRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IQueryable<UserSys> GetQuery()
        {
            return _unitOfWork.Query<UserSys>();
        }

        public List<UserSys> Get()
        {
            var user = GetQuery()
                .AsNoTracking()
                .Include(r => r.UserRole)
                .Where(x => !x.UserRole.IsAdmin)
                .ToList();

            return user;
        }

        public UserSys GetById(int id)
        {
            var user = GetQuery()
                .AsNoTracking()
                .Include(r => r.UserRole)
                .Where(x => !x.UserRole.IsAdmin)
                .FirstOrDefault(x => x.Id == id);

            if (user == null)
                throw new NotFoundException("Seller not found");

            return user;
        }
    }
}
