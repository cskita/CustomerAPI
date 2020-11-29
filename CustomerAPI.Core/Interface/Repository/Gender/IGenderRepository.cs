using System.Collections.Generic;
using GenderModel = CustomerAPI.Core.Model.Gender;

namespace CustomerAPI.Core.Interface.Repository.Gender
{
    public interface IGenderRepository
    {
        List<GenderModel.Gender> Get();
        GenderModel.Gender GetById(int id);
    }
}
