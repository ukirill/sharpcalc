using DBModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.Models;
using DBModel.Helpers;

namespace DBModel.Managers
{
    public class EFUserRepository : IUserRepository
    {
        public IEnumerable<User> GetAll(string sortBy = "")
        {
            var result = new List<User>();
            using (var context = new CalcContext())
            {
                return context.Users.ToList();
            }
        }

        public User Load(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(User entity)
        {
            using (var context = new CalcContext())
            {
                context.Users.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Validate(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login)) return false;
            if (string.IsNullOrWhiteSpace(password)) return false;
            using (var context = new CalcContext())
            {
                return context.Users.FirstOrDefault(u => u.Login == login && u.Password == password) != null;
            }
        }
    }
}
