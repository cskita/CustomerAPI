using System;
using System.Collections.Generic;
using CustomerAPI.Framework.Domain;
using CustomerAPI.Core.Interface.Service.Customer;
using CustomerAPI.Core.Interface.Repository.Customer;
using CustomerModel = CustomerAPI.Core.Model.Customer;

namespace CustomerAPI.Service.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public BaseResult<List<CustomerModel.Customer>> Get()
        {
            try
            {
                var customers = _customerRepository.Get();

                return BaseResult<List<CustomerModel.Customer>>.OK(customers);
            }
            catch (Exception e)
            {
                return BaseResult<List<CustomerModel.Customer>>.NotOK(e.Message);
            }
        }

        public BaseResult<List<CustomerModel.Customer>> GetWithAllRelations(CustomerModel.CustomerFilter filterModel)
        {
            try
            {
                var customers = _customerRepository.GetWithAllRelations(filterModel);

                return BaseResult<List<CustomerModel.Customer>>.OK(customers);
            }
            catch (Exception e)
            {
                return BaseResult<List<CustomerModel.Customer>>.NotOK(e.Message);
            }
        }

        public BaseResult<CustomerModel.Customer> GetById(int id)
        {
            try
            {
                var customer = _customerRepository.GetById(id);

                return BaseResult<CustomerModel.Customer>.OK(customer);
            }
            catch (Exception e)
            {
                return BaseResult<CustomerModel.Customer>.NotOK(e.Message);
            }
        }

        public BaseResult<CustomerModel.Customer> GetByIdWithAllRelations(int id)
        {
            try
            {
                var customer = _customerRepository.GetByIdWithAllRelations(id);

                return BaseResult<CustomerModel.Customer>.OK(customer);
            }
            catch (Exception e)
            {
                return BaseResult<CustomerModel.Customer>.NotOK(e.Message);
            }
        }
    }
}
