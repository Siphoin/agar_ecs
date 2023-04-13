using System.Collections.Generic;

namespace AgarMirror.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        void Initialize();

        IEnumerable<T> GetData();
    }
}
