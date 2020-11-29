using System;
using System.Collections.Generic;
using AutoMapper;
using CustomerAPI.Application.DTO.Customer.ViewModel;
using CustomerAPI.Core.Interface.Service.Customer;
using CustomerAPI.Framework.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Application.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService,
                                        IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        // GET: api/customer
        [HttpGet]
        public ActionResult<BaseResult<List<CustomerViewModel>>> Get()
        {
            var result = _customerService.Get();

            if (result.Success)
            {
                var resultMap = _mapper.Map<List<CustomerViewModel>>(result.Data);

                return BaseResult<List<CustomerViewModel>>.OK(resultMap);
            }

            return BaseResult<List<CustomerViewModel>>.NotOK(result.Messages);
        }

        // GET api/customer/5
        [HttpGet("{id}")]
        public ActionResult<BaseResult<CustomerViewModel>> Get(int id)
        {
 
            var result = _customerService.GetById(id);

            if (result.Success)
            {
                var resultMap = _mapper.Map<CustomerViewModel>(result.Data);

                return BaseResult<CustomerViewModel>.OK(resultMap);
            }

            return BaseResult<CustomerViewModel>.NotOK(result.Messages);

        }
    }
}
