using System;
using System.Collections.Generic;
using CustomerAPI.Framework.Domain;
using CustomerAPI.Core.Model.User;
using CustomerAPI.Core.Interface.Service.Seller;
using CustomerAPI.Core.Interface.Repository.Seller;

namespace CustomerAPI.Service.Seller
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;

        public SellerService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public BaseResult<List<UserSys>> Get()
        {
            try
            {
                var users = _sellerRepository.Get();

                return BaseResult<List<UserSys>>.OK(users);
            }
            catch (Exception e)
            {
                return BaseResult<List<UserSys>>.NotOK(e.Message);
            }
        }

        public BaseResult<UserSys> GetById(int id)
        {
            try
            {
                var user = _sellerRepository.GetById(id);

                return BaseResult<UserSys>.OK(user);
            }
            catch (Exception e)
            {
                return BaseResult<UserSys>.NotOK(e.Message);
            }
        }
    }
}
