using System.Collections.Generic;
using RegionModel = CustomerAPI.Core.Model.Region.Region;

namespace CustomerAPI.Core.Interface.Repository.Region
{
    public interface IRegionRepository
    {
        List<RegionModel> Get();
        RegionModel GetById(int id);
    }
}
