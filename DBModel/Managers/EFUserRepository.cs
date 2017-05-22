using DBModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.Models;
using DBModel.Helpers;
using WebCalc.Managers;
using System.Data.Entity;

namespace DBModel.Managers
{
    public class EFUserRepository : BaseRepository<User>, IUserRepository
    {
        private DbSet<User> Users { get; set; }

        public EFUserRepository(DbContext context) : base(context)
        {
            Users = _db.Set<User>();
        }

        public override IEnumerable<User> GetAll(string sortBy = "")
        {
            var result = new List<User>();
            return Users.ToList();
        
        }

        public override User Load(long id)
        {
            throw new NotImplementedException();
        }

        public override void Save(User entity)
        {
                Users.Add(entity);
                _db.SaveChanges();
        }

        public override void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Validate(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login)) return false;
            if (string.IsNullOrWhiteSpace(password)) return false;

            return Users.FirstOrDefault(u => u.Login == login && u.Password == password) != null;

        }
    }
}
