namespace UrunYonetim6584Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UrunYonetim6584.Data.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "UrunYonetim6584.Data.DatabaseContext";
        }

        protected override void Seed(UrunYonetim6584.Data.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.
            if (!context.Users.Any())  // eğer veritabanında hiç kayıt yoksa
            {
                context.Users.Add(new UrunYonetim6584.Entities.User()  // db deki users tablosuna aşağıdaki kaydı ekle.
                {
                    CreateDate = System.DateTime.Now,
                    Email = "admin@6584.com",
                    IsActive = true,
                    IsAdmin = true,
                    Name = "admin",
                    Username = "admin",
                    Password = "123"
                });
                context.SaveChanges(); // değişiklikleri db ye işle.
            }
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
