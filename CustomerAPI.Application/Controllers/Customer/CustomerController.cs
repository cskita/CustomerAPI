using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CustomerAPI.Application.DTO.Customer.ViewModel;
using CustomerAPI.Core.Interface.Service.Customer;
using CustomerAPI.Framework.Domain;
using CustomerAPI.Application.DTO.Customer.InputModel;
using CustomerAPI.Core.Model.Customer;

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
        public ActionResult<BaseResult<List<CustomerViewModel>>> Get([FromQuery] CustomerInputModel inputModel)
        {
            CustomerFilter customer = null;

            if (inputModel != null)
                customer = _mapper.Map<CustomerFilter>(inputModel);

            var result = _customerService.GetWithAllRelations(customer);

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
            var result = _customerService.GetByIdWithAllRelations(id);

            if (result.Success)
            {
                var resultMap = _mapper.Map<CustomerViewModel>(result.Data);

                return BaseResult<CustomerViewModel>.OK(resultMap);
            }

            return BaseResult<CustomerViewModel>.NotOK(result.Messages);

        }
    }
}
