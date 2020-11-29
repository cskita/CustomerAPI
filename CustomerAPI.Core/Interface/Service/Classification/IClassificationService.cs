using CustomerAPI.Framework.Domain;
using System.Collections.Generic;
using ClassificationModel = CustomerAPI.Core.Model.Classification;

namespace CustomerAPI.Core.Interface.Service.Classification
{
    public interface IClassificationService
    {
        BaseResult<List<ClassificationModel.Classification>> Get();

        BaseResult<ClassificationModel.Classification> GetById(int id);
    }
}
