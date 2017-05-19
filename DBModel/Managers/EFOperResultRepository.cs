using DBModel.Helpers;
using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalc.Managers;

namespace DBModel.Managers
{
    public class EFOperResultRepository : IOperationResultRepository
    {
        public IEnumerable<OperationResult> GetAll(string sortBy = "")
        {
            var result = new List<OperationResult>();
            using (var context = new CalcContext())
            {
                return context.OperationResults.ToList();
            }
        }

        public OperationResult Load(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(OperationResult entity)
        {
            using (var context = new CalcContext())
            {
                context.OperationResults.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(OperationResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
