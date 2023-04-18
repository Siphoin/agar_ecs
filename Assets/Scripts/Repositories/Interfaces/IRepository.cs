using System.Collections.Generic;

namespace AgarMirror.Repositories.Interfaces
{
    public interface IRepository<T> : IRepositoryBase
    {
        IEnumerable<T> GetEnumerable();

         T GetData();
    }
}
