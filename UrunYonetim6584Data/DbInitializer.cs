using System.Data.Entity;
using System.Linq;

namespace UrunYonetim6584.Data
{
    internal class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext> // CreateDatabaseIfNotExists<DatabaseContext> // eğer veritabanı yoksa DataBaseContext deki dbsetlere bakarak oluştur.
        // gerçek projeler de bunlar kullanılmaz.
    {
        protected override void Seed(DatabaseContext context)
        {
            // seed metodu veritabanı oluştuktan sonra çalışır ve burada tablolara başlangıç kayıtları atabiliriz.
            if (!context.Users.Any())  // eğer veritabanında hiç kayıt yoksa
            {
                context.Users.Add(new Entities.User()  // db deki users tablosuna aşağıdaki kaydı ekle.
                {
                    CreateDate = System.DateTime.Now,
                    Email = "admin@6584.com",
                    IsActive = true,
                    IsAdmin = true,
                    Name = "safa",
                    Username = "safahaslak",
                    Password = "1234"
                });
                context.SaveChanges(); // değişiklikleri db ye işle.
            }
            base.Seed(context);
        }
    }
}
