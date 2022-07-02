using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T>
    {
        public List<T> GetAll(Expression<Func<T, bool>> filter = null);

        public T Get(Expression<Func<T, bool>> filter = null);

        public void Add(T Entity);
        public void Update(T Entity);
        public void Delete(T Entity);
    }
}
