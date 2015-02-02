using EntityData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityData.Repositories
{
    public class UserRepository : IRepository<User, int>
    {
        private LoginContext _context;

        public UserRepository(LoginContext context)
        {
            _context = context;
        }

        public IEnumerable<User> Table
        {
            get { return _context.Users; }
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public int Add(User item)
        {
            _context.Users.Add(item);

            _context.SaveChanges();

            return item.Id;
        }

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            Delete(user);
        }

        public void Delete(User item)
        {
            _context.Users.Remove(item);

            _context.SaveChanges();
        }
    }
}
