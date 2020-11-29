using System.Collections.Generic;
using ClassificationModel = CustomerAPI.Core.Model.Classification;

namespace CustomerAPI.Core.Interface.Repository.Classification
{
    public interface IClassificationRepository
    {
        List<ClassificationModel.Classification> Get();
        ClassificationModel.Classification GetById(int id);
    }
}
