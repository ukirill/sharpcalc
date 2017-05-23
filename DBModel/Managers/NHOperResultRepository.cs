using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.Models;
using WebCalc.Managers;
using NHibernate;
using DBModel.Helpers;
using static DBModel.Managers.EFOperResultRepository;

namespace DBModel.Managers
{
    public class NHOperResultRepository : IOperationResultRepository
    {
        public IEnumerable<OperationResult> GetAll()
        {
            var result = new List<OperationResult>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                result.AddRange(session.QueryOver<OperationResult>().List<OperationResult>());
            }
            return result.Select(o => { o.OperationName = o.OperationName.Trim(); return o; });
        }

        public IEnumerable<OperationResult> GetAll(bool flag)
        {
            return GetAll();
        }

        public IEnumerable<OperationResult> GetAll(string filter)
        {
            var res = GetAll().Where(o => o.OperationName == filter);
            return res;
        }

        public IEnumerable<TopOperationsElement> GetTop(int limit)
        {

            var res = GetAll()
                .GroupBy(o => o.OperationName)
                .OrderByDescending(g => g.Count())
                .Take(3)
                .Select(e =>  new TopOperationsElement() { OperationName = e.Key, OperationCount = e.Count()});
            return res;
            
        }

        public OperationResult Load(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(OperationResult entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(entity);
                transaction.Commit();
            }
        }

        public void Update(OperationResult entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(entity);
                transaction.Commit();
            }
        }

        public void Delete(OperationResult entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(entity);
                transaction.Commit();
            }
        }

        public void Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(session.Get<OperationResult>(id));
                transaction.Commit();
            }
        }
    }
}
