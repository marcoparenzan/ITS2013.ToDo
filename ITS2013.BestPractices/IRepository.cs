using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2013.BestPractices
{
    public interface IRepository<T>
    {
        void Add(T item);
        T Get(Guid id);
        void Update(T item);
    }
}
