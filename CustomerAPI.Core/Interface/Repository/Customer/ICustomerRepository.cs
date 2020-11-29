using System.Collections.Generic;
using CustomerModel = CustomerAPI.Core.Model.Customer;

namespace CustomerAPI.Core.Interface.Repository.Customer
{
    public interface ICustomerRepository
    {
        List<CustomerModel.Customer> Get();
        CustomerModel.Customer GetById(int id);
    }
}
