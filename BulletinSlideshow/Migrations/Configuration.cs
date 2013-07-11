namespace BulletinSlideshow.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BulletinSlideshow.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BulletinSlideshow.Models.BulletinSlideshowContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BulletinSlideshow.Models.BulletinSlideshowContext context)
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
            if (context.Members.Count() == 0)
            {
                context.Members.AddOrUpdate(new Member
                {
                    Id = 1,
                    Account = "admin",
                    Password = "aQE0irDerNnbapnawQnoppxBC8EG+SL+0M0+LzuzYw+vMYYZeeEbtI3KEQB58PINNGy9mlkf+gEYaP6PKcA0/jl1eVlOdmhocXltZXI0ZFRlNTVac3p6Rld0clVoZjd1c2U2bg==",
                    Name = "Admin",
                    CreateOn = DateTime.Now,
                    LastLoginOn = null
                });
            }
        }
    }
}
