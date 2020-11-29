using System;
using System.Collections.Generic;
using System.Text;
using CustomerAPI.Framework.Domain;
using ClassificationModel = CustomerAPI.Core.Model.Classification;
using CustomerAPI.Core.Interface.Service.Classification;
using CustomerAPI.Core.Interface.Repository.Classification;

namespace CustomerAPI.Service.Classification
{
    public class ClassificationService : IClassificationService
    {
        private readonly IClassificationRepository _classificationRepository;

        public ClassificationService(IClassificationRepository classificationRepository)
        {
            _classificationRepository = classificationRepository;
        }

        public BaseResult<List<ClassificationModel.Classification>> Get()
        {
            try
            {
                var classifications = _classificationRepository.Get();

                return BaseResult<List<ClassificationModel.Classification>>.OK(classifications);
            }
            catch (Exception e)
            {
                return BaseResult<List<ClassificationModel.Classification>>.NotOK(e.Message);
            }
        }

        public BaseResult<ClassificationModel.Classification> GetById(int id)
        {
            try
            {
                var classification = _classificationRepository.GetById(id);

                return BaseResult<ClassificationModel.Classification>.OK(classification);
            }
            catch (Exception e)
            {
                return BaseResult<ClassificationModel.Classification>.NotOK(e.Message);
            }
        }
    }
}
