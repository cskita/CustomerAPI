using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerAPI.Infra.Data.Context;
using GenderModel = CustomerAPI.Core.Model.Gender;
using CustomerAPI.Core.Interface.Repository.Gender;
using CustomerAPI.Framework.GeneralException;

namespace CustomerAPI.Infra.Data.Repository.Gender
{
    public class GenderRepository : IGenderRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenderRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IQueryable<GenderModel.Gender> GetQuery()
        {
            return _unitOfWork.Query<GenderModel.Gender>();
        }

        public List<GenderModel.Gender> Get()
        {
            return GetQuery().AsNoTracking().ToList();
        }

        public GenderModel.Gender GetById(int id)
        {
            var gender = GetQuery().AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (gender == null)
                throw new NotFoundException("Gender is not found");

            return gender;
        }
    }
}
