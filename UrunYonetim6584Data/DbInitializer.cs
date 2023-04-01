﻿using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunYonetim6584.Data;
using System.ComponentModel.DataAnnotations;

namespace UrunYonetim6584.Data
{
    internal class DbInitializer : CreateDatabaseIfNotExists<DatabaseContext> // eğer veritabanı yoksa DataBaseContext deki dbsetlere bakarak oluştur.
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
                    Name = "admin",
                    Username = "admin",
                    Password = "123"
                });
                context.SaveChanges(); // değişiklikleri db ye işle.
            }
            base.Seed(context);
        }
    }
}
