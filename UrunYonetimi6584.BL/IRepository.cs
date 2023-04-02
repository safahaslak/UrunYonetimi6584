using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunYonetim6584.Entities;
using System.Linq.Expressions; // veri sorgulama işlemleri yapabilmek için.

namespace UrunYonetimi6584.BL
{
    public interface IRepository<T> // interface in yanına <T> ekleyerek generic-genel kullanılabilir hale getirdik.
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T , bool>> expression); // x => x.name == "elektronik". Geriye sorgu sonucunda gönderilen class ın db deki listesine döner.
        void Add(T entity);
        T Find(int id);
        T Get(Expression<Func<T, bool>> expression);  // geriye sorgu sonucunda 1 kayıt döner.
        void Update(T entity);
        void Delete(T entity);
        int Save();
    }
}
