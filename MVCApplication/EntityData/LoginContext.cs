using EntityData.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityData
{
    public class LoginContext : DbContext
    {
        private static readonly string _connectionString = "server=localhost;user id=postgres;password=default;database=session_test";

        public LoginContext()
            : base(new NpgsqlConnection(_connectionString), true)
        {

        }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
