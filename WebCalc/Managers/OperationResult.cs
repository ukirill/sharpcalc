using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCalc.Managers
{
    /// <summary>
    /// Результат выполнения операции
    /// </summary>

    public class OperationResult
    {
        public long Id { get; set; }

        public string OperationName { get; set; }

        public string Arguments { get; set; }

        public double? Result { get; set; }
        /// <summary>
        /// Продолжительность выпоплнения
        /// </summary>
        public long ExecutionTime { get; set; }

        public DateTime ExecutionDate { get; set; }
    }
}