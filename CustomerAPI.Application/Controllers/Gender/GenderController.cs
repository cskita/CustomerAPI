using System.Collections.Generic;
using AutoMapper;
using CustomerAPI.Application.DTO.Gender.ViewModel;
using CustomerAPI.Core.Interface.Service.Gender;
using CustomerAPI.Framework.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Application.Controllers.Gender
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;
        private readonly IMapper _mapper;

        public GenderController(IGenderService genderService,
                                        IMapper mapper)
        {
            _genderService = genderService;
            _mapper = mapper;
        }

        // GET: api/gender
        [HttpGet]
        public ActionResult<BaseResult<List<GenderViewModel>>> Get()
        {
            var result = _genderService.Get();

            if (result.Success)
            {
                var resultMap = _mapper.Map<List<GenderViewModel>>(result.Data);

                return BaseResult<List<GenderViewModel>>.OK(resultMap);
            }

            return BaseResult<List<GenderViewModel>>.NotOK(result.Messages);
        }

        // GET api/gender/5
        [HttpGet("{id}")]
        public ActionResult<BaseResult<GenderViewModel>> Get(int id)
        {
            var result = _genderService.GetById(id);

            if (result.Success)
            {
                var resultMap = _mapper.Map<GenderViewModel>(result.Data);

                return BaseResult<GenderViewModel>.OK(resultMap);
            }

            return BaseResult<GenderViewModel>.NotOK(result.Messages);
        }
    }
}
