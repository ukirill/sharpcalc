using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalc.Managers;

namespace DBModel.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool Validate(string login, string password);
    }
}
