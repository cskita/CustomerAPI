using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CustomerAPI.Core.Interface.Service.City;
using CustomerAPI.Framework.Domain;
using CustomerAPI.Application.DTO.City.ViewModel;

namespace CustomerAPI.Application.Controllers.City
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CityController(ICityService cityService,
                              IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        // GET: api/city
        [HttpGet]
        public ActionResult<BaseResult<List<CityViewModel>>> Get()
        {
            var result = _cityService.Get();

            if (result.Success)
            {
                var resultMap = _mapper.Map<List<CityViewModel>>(result.Data);

                return BaseResult<List<CityViewModel>>.OK(resultMap);
            }

            return BaseResult<List<CityViewModel>>.NotOK(result.Messages);
        }

        // GET api/city/5
        [HttpGet("{id}")]
        public ActionResult<BaseResult<CityViewModel>> Get(int id)
        {
            var result = _cityService.GetById(id);

            if (result.Success)
            {
                var resultMap = _mapper.Map<CityViewModel>(result.Data);

                return BaseResult<CityViewModel>.OK(resultMap);
            }

            return BaseResult<CityViewModel>.NotOK(result.Messages);
        }
    }
}
