using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityData.Models
{
    public class Session
    {
        public Guid Id { get; set; }

        //Indexing on userId
        //If user has session id cached(cookies) then try to auth with that else request login.
        public int UserId { get; set; }

        public DateTime LastRequest { get; set; }
    }
}
