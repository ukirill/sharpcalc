using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCalc.Managers
{
    /// <summary>
    /// Базовый интерфейс хранилища данных
    /// </summary>
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public DbContext _db { get; set; }

        public BaseRepository(DbContext context)
        {
            _db = context;
        }

        public virtual T Load(long id)
        {
            return null;
        }

        public virtual void Save(T entity)
        {
        }

        public virtual void Update(T entity)
        {
        }

        public virtual IEnumerable<T> GetAll()
        {
            return null;
        }

        public virtual IEnumerable<T> GetAll(bool flag)
        {
            return null;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
