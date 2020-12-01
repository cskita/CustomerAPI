using System.Collections.Generic;
using ClassificationModel = CustomerAPI.Core.Model.Classification.Classification;

namespace CustomerAPI.Core.Interface.Repository.Classification
{
    public interface IClassificationRepository
    {
        List<ClassificationModel> Get();
        ClassificationModel GetById(int id);
    }
}
