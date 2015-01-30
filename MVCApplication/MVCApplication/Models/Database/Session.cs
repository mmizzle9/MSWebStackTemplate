using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCApplication.Models
{
    public class Session
    {
        public int Id { get; set; }

        //Indexing on userId
        //If user has session id cached(cookies) then try to auth with that else request login.
        public int UserId { get; set; }

        public DateTime LastRequest { get; set; }
    }
}
