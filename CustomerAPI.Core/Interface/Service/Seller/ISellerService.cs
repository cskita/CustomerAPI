using CustomerAPI.Framework.Domain;
using System.Collections.Generic;
using CustomerAPI.Core.Model.User;

namespace CustomerAPI.Core.Interface.Service.Seller
{
    public interface ISellerService
    {
        BaseResult<List<UserSys>> Get();
        BaseResult<UserSys> GetById(int id);
    }
}
