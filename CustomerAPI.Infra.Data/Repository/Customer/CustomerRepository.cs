using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerAPI.Infra.Data.Context;
using CustomerModel = CustomerAPI.Core.Model.Customer;
using CustomerAPI.Core.Interface.Repository.Customer;
using CustomerAPI.Framework.GeneralException;

namespace CustomerAPI.Infra.Data.Repository.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IQueryable<CustomerModel.Customer> GetQuery()
        {
            return _unitOfWork.Query<CustomerModel.Customer>();
        }

        public List<CustomerModel.Customer> Get()
        {
            return GetQuery().AsNoTracking().ToList();
        }

        public CustomerModel.Customer GetById(int id)
        {
            var customer = GetQuery().AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (customer == null)
                throw new NotFoundException("Customer is not found");

            return customer;
        }
    }
}
