using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityData.Repositories
{
    /// <summary>
    /// Base table functionality
    /// </summary>
    /// <typeparam name="T">Repository object type</typeparam>
    /// <typeparam name="P">Primary key type</typeparam>
    public interface IRepository<T, P>
    {
        IEnumerable<T> Table { get; }

        T GetById(P id);

        P Add(T item);

        void Delete(P id);

        void Delete(T item);
    }
}
