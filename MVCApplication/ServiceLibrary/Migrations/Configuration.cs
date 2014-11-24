namespace ServiceLibrary.Migrations
{
    using ServiceLibrary.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.TestModels.AddOrUpdate(
                new[]
                {
                    new TestModel{Column1 = "Test 1 Col 1", Column2 = "Test 1 Col 2" },
                    new TestModel{Column1 = "Test 2 Col 1", Column2 = "Test 2 Col 2" },
                    new TestModel{Column1 = "Test 3 Col 1", Column2 = "Test 3 Col 2" },
                });
        }
    }
}
