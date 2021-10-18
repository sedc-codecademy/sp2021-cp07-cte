using Psyent.DataModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Psyent.DataAccess.EntityFramework
{
    public class UserRepository : IRepository<User>
    {
        private readonly PsyentDbContext _db;

        public UserRepository(PsyentDbContext db)
        {
            _db = db;
        }

        public void Add(User entity)
        {
            _db.Users.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(User entity)
        {
            User user = _db.Users.SingleOrDefault(x => x.Id == entity.Id);
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public void Update(User entity)
        {
            User user = _db.Users.SingleOrDefault(x => x.Id == entity.Id);
            if (user != null)
            {
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Username = entity.Username;
                user.Password = entity.Password;
            }
            _db.SaveChanges();
        }
    }
}
