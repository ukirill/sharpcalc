using DBModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBModel.Models
{
    /// <summary>
    /// Результат выполнения операции
    /// </summary>

    public class OperationResult
    {
        public virtual int Id { get; set; }

        public virtual string OperationName { get; set; }
   
        public virtual string Arguments { get; set; }

        public virtual double? Result { get; set; }
        /// <summary>
        /// Продолжительность выпоплнения
        /// </summary>
        public virtual long ExecutionTime { get; set; }

        public virtual DateTime ExecutionDate { get; set; }

        public virtual User User { get; set; }
    }
}