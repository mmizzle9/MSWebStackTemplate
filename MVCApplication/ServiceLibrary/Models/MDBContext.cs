using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary.Models
{
    public class MDBContext : DbContext
    {
        public MDBContext() : base(@"Data Source=MSI_GS70\SQLEXPRESS;Integrated Security=True; initial catalog=TestDB;")
        {
            Database.SetInitializer<MDBContext>(new DropCreateDatabaseIfModelChanges<MDBContext>());
        }

        public DbSet<TestModel> TestModels { get; set; }
    }
}
