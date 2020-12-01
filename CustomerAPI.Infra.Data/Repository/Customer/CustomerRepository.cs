using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerAPI.Infra.Data.Context;
using CustomerAPI.Core.Interface.Repository.Customer;
using CustomerAPI.Framework.GeneralException;
using CustomerModel = CustomerAPI.Core.Model.Customer;

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

        public List<CustomerModel.Customer> GetWithAllRelations(CustomerModel.CustomerFilter customerFilter)
        {
            var customer = GetQuery()
                .Include(x => x.Gender)
                .Include(x => x.City)
                .Include(x => x.Region)
                .Include(x => x.Classification)
                .Include(x => x.UserSys)
                .AsNoTracking()
                .ToList()
                .Where(p => p.Name.StartsWith(customerFilter.Name ?? String.Empty, StringComparison.InvariantCultureIgnoreCase));

            if ((customerFilter.CityId ?? 0) > 0)
                customer = customer.Where(x => x.CityId == customerFilter.CityId);
            if ((customerFilter.ClassificationId ?? 0) > 0)
                customer = customer.Where(x => x.ClassificationId == customerFilter.ClassificationId);
            if ((customerFilter.GenderId ?? 0) > 0)
                customer = customer.Where(x => x.GenderId == customerFilter.GenderId);
            if ((customerFilter.RegionId ?? 0) > 0)
                customer = customer.Where(x => x.RegionId == customerFilter.RegionId);
            if ((customerFilter.SellerId ?? 0) > 0)
                customer = customer.Where(x => x.UserId == customerFilter.SellerId);
            if (customerFilter.LastPurchaseFinal.HasValue)
                customer = customer.Where(x => x.LastPurchase <= customerFilter.LastPurchaseFinal);
            if (customerFilter.LastPurchaseInitial.HasValue)
                customer = customer.Where(x => x.LastPurchase >= customerFilter.LastPurchaseInitial);

            return customer.ToList();
        }

        public CustomerModel.Customer GetById(int id)
        {
            var customer = GetQuery()
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (customer == null)
                throw new NotFoundException("Customer not found");

            return customer;
        }

        public CustomerModel.Customer GetByIdWithAllRelations(int id)
        {
            var customer = GetQuery()
                .Include(x => x.Gender)
                .Include(x => x.City)
                .Include(x => x.Region)
                .Include(x => x.Classification)
                .Include(x => x.UserSys)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (customer == null)
                throw new NotFoundException("Customer not found");

            return customer;
        }

    }
}
