using System.Collections.Generic;
using AutoMapper;
using CustomerAPI.Application.DTO.Seller.ViewModel;
using CustomerAPI.Core.Interface.Service.User;
using CustomerAPI.Framework.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Application.Controllers.Seller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly IUserSysService _userSysService;
        private readonly IMapper _mapper;

        public SellerController(IUserSysService userSysService,
                                IMapper mapper)
        {
            _userSysService = userSysService;
            _mapper = mapper;
        }

        // GET: api/seller
        [HttpGet]
        public ActionResult<BaseResult<List<SellerViewModel>>> Get()
        {
            var result = _userSysService.Get();

            if (result.Success)
            {
                var resultMap = _mapper.Map<List<SellerViewModel>>(result.Data);

                return BaseResult<List<SellerViewModel>>.OK(resultMap);
            }

            return BaseResult<List<SellerViewModel>>.NotOK(result.Messages);
        }

        // GET api/seller/5
        [HttpGet("{id}")]
        public ActionResult<BaseResult<SellerViewModel>> Get(int id)
        {
            var result = _userSysService.GetById(id);

            if (result.Success)
            {
                var resultMap = _mapper.Map<SellerViewModel>(result.Data);

                return BaseResult<SellerViewModel>.OK(resultMap);
            }

            return BaseResult<SellerViewModel>.NotOK(result.Messages);
        }
    }
}
