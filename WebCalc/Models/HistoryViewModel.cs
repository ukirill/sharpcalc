using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCalc.Managers;

namespace WebCalc.Models
{
    public class HistoryViewModel
    {
        public IEnumerable<OperationResult> OperationHistory { get; set; }
        public class Top3OperationsElement
        {
            public string OperationName { get; set; }
            public int OperationCount { get; set; }
        }
        public IEnumerable<Top3OperationsElement> Top3 { get; set; }
        public string Filter { get; set; }
    }
}