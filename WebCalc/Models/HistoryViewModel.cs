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

    }
}