using CustomerAPI.Framework.Domain;
using System.Collections.Generic;
using GenderModel = CustomerAPI.Core.Model.Gender;

namespace CustomerAPI.Core.Interface.Service.Gender
{
    public interface IGenderService
    {
        BaseResult<List<GenderModel.Gender>> Get();

        BaseResult<GenderModel.Gender> GetById(int id);
    }
}
