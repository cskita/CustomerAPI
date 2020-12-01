using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerAPI.Infra.Data.Context;
using CustomerAPI.Core.Interface.Repository.Gender;
using CustomerAPI.Framework.GeneralException;
using GenderModel = CustomerAPI.Core.Model.Gender.Gender;

namespace CustomerAPI.Infra.Data.Repository.Gender
{
    public class GenderRepository : IGenderRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenderRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IQueryable<GenderModel> GetQuery()
        {
            return _unitOfWork.Query<GenderModel>();
        }

        public List<GenderModel> Get()
        {
            return GetQuery().AsNoTracking().ToList();
        }

        public GenderModel GetById(int id)
        {
            var gender = GetQuery().AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (gender == null)
                throw new NotFoundException("Gender not found");

            return gender;
        }
    }
}
