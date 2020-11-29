using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace CustomerAPI.Infra.Data.Context
{
    public interface IUnitOfWork : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
    }
}