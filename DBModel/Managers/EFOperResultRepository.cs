using DBModel.Helpers;
using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalc.Managers;

namespace DBModel.Managers
{
    public class EFOperResultRepository : BaseRepository<OperationResult>, IOperationResultRepository
    {
        public DbSet<OperationResult> OperationResults{ get; set; }

        public class TopOperationsElement
        {
            public string OperationName { get; set; }
            public int OperationCount { get; set; }
        }

        public EFOperResultRepository(DbContext context) : base(context)
        {
            OperationResults = context.Set<OperationResult>();
        }

        public override IEnumerable<OperationResult> GetAll()
        {
            var result = new List<OperationResult>();
            return OperationResults.Include(o => o.User).ToList();

        }

        public override IEnumerable<OperationResult> GetAll(bool flag)
        {
            if (flag) return OperationResults.Include(it => it.User).ToList();
            else return GetAll();    
        }

        public IEnumerable<OperationResult> GetAll(string filter)
        {
            return OperationResults.Where(x => x.OperationName == filter).Include(x => x.User);
        }

        public override OperationResult Load(long id)
        {
            throw new NotImplementedException();
        }

        public override void Save(OperationResult entity)
        {
                OperationResults.Add(entity);
                _db.SaveChanges();
        }

        public override void Update(OperationResult entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TopOperationsElement> GetTop(int limit = 3)
        {
            var result = new Dictionary<string, int>();
            var param = new System.Data.SqlClient.SqlParameter("@limit", limit);
            var data = _db.Database.SqlQuery<TopOperationsElement>(
                 $@"Select Top {limit} OperationName, Count(*) as OperationCount 
                            From OperationResult 
                            Group By OperationName 
                            Order By OperationCount DESC"
                ) as IEnumerable<TopOperationsElement>;
            return data;
             
        }
    }
}
