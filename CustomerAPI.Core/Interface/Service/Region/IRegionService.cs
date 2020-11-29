using CustomerAPI.Framework.Domain;
using System.Collections.Generic;
using RegionModel = CustomerAPI.Core.Model.Region;

namespace CustomerAPI.Core.Interface.Service.Region
{
    public interface IRegionService
    {
        BaseResult<List<RegionModel.Region>> Get();

        BaseResult<RegionModel.Region> GetById(int id);
    }
}
