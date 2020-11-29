using System.Collections.Generic;
using RegionModel = CustomerAPI.Core.Model.Region;

namespace CustomerAPI.Core.Interface.Repository.Region
{
    public interface IRegionRepository
    {
        List<RegionModel.Region> Get();
        RegionModel.Region GetById(int id);
    }
}
