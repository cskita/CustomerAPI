using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerAPI.Infra.Data.Context;
using ClassificationModel = CustomerAPI.Core.Model.Classification;
using CustomerAPI.Core.Interface.Repository.Classification;
using CustomerAPI.Framework.GeneralException;

namespace CustomerAPI.Infra.Data.Repository.Classification
{
    public class ClassificationRepository : IClassificationRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassificationRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IQueryable<ClassificationModel.Classification> GetQuery()
        {
            return _unitOfWork.Query<ClassificationModel.Classification>();
        }

        public List<ClassificationModel.Classification> Get()
        {
            return GetQuery().AsNoTracking().ToList();
        }

        public ClassificationModel.Classification GetById(int id)
        {
            var classification = GetQuery().AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (classification == null)
                throw new NotFoundException("Classification is not found");

            return classification;
        }
    }
}
