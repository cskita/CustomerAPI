using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerAPI.Infra.Data.Context;
using CustomerAPI.Core.Interface.Repository.Classification;
using CustomerAPI.Framework.GeneralException;
using ClassificationModel = CustomerAPI.Core.Model.Classification.Classification;

namespace CustomerAPI.Infra.Data.Repository.Classification
{
    public class ClassificationRepository : IClassificationRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassificationRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IQueryable<ClassificationModel> GetQuery()
        {
            return _unitOfWork.Query<ClassificationModel>();
        }

        public List<ClassificationModel> Get()
        {
            return GetQuery().AsNoTracking().ToList();
        }

        public ClassificationModel GetById(int id)
        {
            var classification = GetQuery().AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (classification == null)
                throw new NotFoundException("Classification not found");

            return classification;
        }
    }
}
