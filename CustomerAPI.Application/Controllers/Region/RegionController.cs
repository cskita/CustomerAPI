using System;
using System.Collections.Generic;
using AutoMapper;
using CustomerAPI.Application.DTO.Region.ViewModel;
using CustomerAPI.Core.Interface.Service.Region;
using CustomerAPI.Framework.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Application.Controllers.Region
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;
        private readonly IMapper _mapper;

        public RegionController(IRegionService regionService,
                                        IMapper mapper)
        {
            _regionService = regionService;
            _mapper = mapper;
        }

        // GET: api/region
        [HttpGet]
        public ActionResult<BaseResult<List<RegionViewModel>>> Get()
        {
            var result = _regionService.Get();

            if (result.Success)
            {
                var resultMap = _mapper.Map<List<RegionViewModel>>(result.Data);

                return BaseResult<List<RegionViewModel>>.OK(resultMap);
            }

            return BaseResult<List<RegionViewModel>>.NotOK(result.Messages);
        }

        // GET api/region/5
        [HttpGet("{id}")]
        public ActionResult<BaseResult<RegionViewModel>> Get(int id)
        {
            var result = _regionService.GetById(id);

            if (result.Success)
            {
                var resultMap = _mapper.Map<RegionViewModel>(result.Data);

                return BaseResult<RegionViewModel>.OK(resultMap);
            }

            return BaseResult<RegionViewModel>.NotOK(result.Messages);
        }
    }
}
