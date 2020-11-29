using System;
using System.Collections.Generic;
using AutoMapper;
using CustomerAPI.Application.DTO.Classification.ViewModel;
using CustomerAPI.Core.Interface.Service.Classification;
using CustomerAPI.Framework.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Application.Controllers.Classification
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationController : ControllerBase
    {
        private readonly IClassificationService _classificationService;
        private readonly IMapper _mapper;

        public ClassificationController(IClassificationService classificationService,
                                        IMapper mapper)
        {
            _classificationService = classificationService;
            _mapper = mapper;
        }

        // GET: api/classification
        [HttpGet]
        public ActionResult<BaseResult<List<ClassificationViewModel>>> Get()
        {
            var result = _classificationService.Get();

            if (result.Success)
            {
                var resultMap = _mapper.Map<List<ClassificationViewModel>>(result.Data);

                return BaseResult<List<ClassificationViewModel>>.OK(resultMap);
            }

            return BaseResult<List<ClassificationViewModel>>.NotOK(result.Messages);
        }

        // GET api/classification/5
        [HttpGet("{id}")]
        public ActionResult<BaseResult<ClassificationViewModel>> Get(int id)
        {
            var result = _classificationService.GetById(id);

            if (result.Success)
            {
                var resultMap = _mapper.Map<ClassificationViewModel>(result.Data);

                return BaseResult<ClassificationViewModel>.OK(resultMap);
            }

            return BaseResult<ClassificationViewModel>.NotOK(result.Messages);
        }
    }
}
