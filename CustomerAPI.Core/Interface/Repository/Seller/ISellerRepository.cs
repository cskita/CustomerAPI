using System.Collections.Generic;
using CustomerAPI.Core.Model.User;

namespace CustomerAPI.Core.Interface.Repository.Seller
{
    public interface ISellerRepository
    {
        List<UserSys> Get();
        UserSys GetById(int id);
    }
}
