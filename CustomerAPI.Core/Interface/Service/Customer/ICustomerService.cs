using CustomerAPI.Framework.Domain;
using System.Collections.Generic;
using CustomerModel = CustomerAPI.Core.Model.Customer;

namespace CustomerAPI.Core.Interface.Service.Customer
{
    public interface ICustomerService
    {
        BaseResult<List<CustomerModel.Customer>> Get();

        BaseResult<CustomerModel.Customer> GetById(int id);
    }
}
