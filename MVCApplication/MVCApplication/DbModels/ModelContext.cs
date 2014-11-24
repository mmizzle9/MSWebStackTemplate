using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCApplication.Models
{
    public class ModelContext : DbContext
    {
        public DbSet<TestModel> ModelSet { get; set; }
    }
}