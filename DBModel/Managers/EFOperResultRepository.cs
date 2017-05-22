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

        public IQueryable<OperationResult> GetAll(string filter)
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
    }
}
