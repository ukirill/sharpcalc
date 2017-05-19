using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalc.Managers;

namespace DBModel.Helpers
{
    public class CalcContext : DbContext
    {
        public CalcContext() : base("EFConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationResult> OperationResults { get; set; }
    }
}
