using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerAPI.Infra.Data.Context;
using RegionModel = CustomerAPI.Core.Model.Region;
using CustomerAPI.Core.Interface.Repository.Region;
using CustomerAPI.Framework.GeneralException;

namespace CustomerAPI.Infra.Data.Repository.Region
{
    public class RegionRepository : IRegionRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegionRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IQueryable<RegionModel.Region> GetQuery()
        {
            return _unitOfWork.Query<RegionModel.Region>();
        }

        public List<RegionModel.Region> Get()
        {
            return GetQuery().AsNoTracking().ToList();
        }

        public RegionModel.Region GetById(int id)
        {
            var region = GetQuery().AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (region == null)
                throw new NotFoundException("Region is not found");

            return region;
        }
    }
}
