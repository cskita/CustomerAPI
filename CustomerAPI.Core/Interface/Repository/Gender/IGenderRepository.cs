using System.Collections.Generic;
using GenderModel = CustomerAPI.Core.Model.Gender.Gender;

namespace CustomerAPI.Core.Interface.Repository.Gender
{
    public interface IGenderRepository
    {
        List<GenderModel> Get();
        GenderModel GetById(int id);
    }
}
