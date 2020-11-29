using System;
using System.Collections.Generic;
using System.Text;
using CustomerAPI.Framework.Domain;
using RegionModel = CustomerAPI.Core.Model.Region;
using CustomerAPI.Core.Interface.Service.Region;
using CustomerAPI.Core.Interface.Repository.Region;

namespace CustomerAPI.Service.Region
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public BaseResult<List<RegionModel.Region>> Get()
        {
            try
            {
                var regions = _regionRepository.Get();

                return BaseResult<List<RegionModel.Region>>.OK(regions);
            }
            catch (Exception e)
            {
                return BaseResult<List<RegionModel.Region>>.NotOK(e.Message);
            }
        }

        public BaseResult<RegionModel.Region> GetById(int id)
        {
            try
            {
                var region = _regionRepository.GetById(id);

                return BaseResult<RegionModel.Region>.OK(region);
            }
            catch (Exception e)
            {
                return BaseResult<RegionModel.Region>.NotOK(e.Message);
            }
        }
    }
}
