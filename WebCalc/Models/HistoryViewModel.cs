using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCalc.Managers;
using static DBModel.Managers.EFOperResultRepository;

namespace WebCalc.Models
{
    public class HistoryViewModel
    {
        public IEnumerable<OperationResult> OperationHistory { get; set; }
        public IEnumerable<TopOperationsElement> Top { get; set; }
        public string Filter { get; set; }
    }
}