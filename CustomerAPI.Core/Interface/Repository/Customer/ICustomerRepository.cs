using System.Collections.Generic;
using CustomerModel = CustomerAPI.Core.Model.Customer;

namespace CustomerAPI.Core.Interface.Repository.Customer
{
    public interface ICustomerRepository
    {
        List<CustomerModel.Customer> Get();
        List<CustomerModel.Customer> GetWithAllRelations(CustomerModel.CustomerFilter customerFilter);
        CustomerModel.Customer GetById(int id);    
    }
}
