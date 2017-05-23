using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DBModel.Managers.EFOperResultRepository;

namespace WebCalc.Managers
{
    public interface IOperationResultRepository : IBaseRepository<OperationResult>
    {
        IEnumerable<OperationResult> GetAll(string filter);
        IEnumerable<TopOperationsElement> GetTop(int limit);
    }
}
