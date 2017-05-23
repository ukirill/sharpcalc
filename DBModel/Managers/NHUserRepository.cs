using DBModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.Models;
using NHibernate;
using DBModel.Helpers;

namespace DBModel.Managers
{
    public class NHUserRepository : IUserRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            var result = new List<User>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                result.AddRange(session.QueryOver<User>().List<User>());
            }
            return result;
        }

        public IEnumerable<User> GetAll(bool flag)
        {
            throw new NotImplementedException();
        }

        public User Load(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(User entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(entity);
                transaction.Commit();
            }
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Validate(string login, string password)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<User>()
                    .Where(user => user.Email == login && user.Password == password)
                    .SingleOrDefault() != null;
            }
        }
    }
}
