using EntityData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityData.Repositories
{
    public class SessionRepository : IRepository<Session, Guid>
    {
        private const int SESSION_TIMEOUT_MINUTES = 15;

        private LoginContext _context;

        public SessionRepository(LoginContext context)
        {
            _context = context;
        }

        public IEnumerable<Session> Table
        {
            get { return _context.Sessions; }
        }

        public Session GetById(Guid id)
        {
            return _context.Sessions.FirstOrDefault(s => s.Id == id);
        }

        public bool IsSessionValid(Guid sessionId, int userId)
        {
            var session = GetById(sessionId);
            if(session == null) return false;

            //session not for user
            if (session.UserId != userId)
                return false;

            if (session.LastRequest.AddMinutes(15) < DateTime.UtcNow)
            {
                //session expired
                Delete(session);
                return false;
            }

            return true;
        }

        public Guid AddForUser(User user)
        {
            var id = new Guid();
            _context.Sessions.Add(new Session
            {
                Id = id,
                UserId = user.Id,
                LastRequest = DateTime.UtcNow,
            });

            _context.SaveChanges();

            return id;
        }

        public bool UpdateSessionTimer(Guid sessionId)
        {
            var session = GetById(sessionId);
            if (session == null)
                return false;
            session.LastRequest = DateTime.UtcNow;

            _context.SaveChanges();

            return true;
        }

        public Guid Add(Session item)
        {
            _context.Sessions.Add(item);

            _context.SaveChanges();

            return item.Id;
        }

        public void Delete(Guid id)
        {
            var session = _context.Sessions.FirstOrDefault(s => s.Id == id);

            Delete(session);
        }

        public void Delete(Session item)
        {
            _context.Sessions.Remove(item);

            _context.SaveChanges();
        }
    }
}
