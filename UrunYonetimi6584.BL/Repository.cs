 using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UrunYonetim6584.Data;
using UrunYonetim6584.Entities;

namespace UrunYonetimi6584.BL
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()  // where den sonrası buraya gönderilecek nesnenin bir class olması, IEntity ile işaretlenmiş olması ve new lenebilir bir nesne olmasını şart koştuğumuzu ifade eder. 
    {
        protected DatabaseContext context;  // EF ile veritabanı context'imiz.
        protected DbSet<T> dbSet;  // DatabaseContext içindeki db set yapısının generic'i
        public Repository() 
        {
            if (context == null) // eğer context boşsa 
            {
                context = new DatabaseContext(); // DatabaseContext ten bir örnek oluştur.
                dbSet = context.Set<T>(); // ve yukarıdaki dbset'i gönderilen class için ayarla.
            }
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Find(int id)
        {
            return dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return dbSet.FirstOrDefault(expression);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression).ToList();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(T entity)
        {
            dbSet.AddOrUpdate(entity);
        }
    } 
}
