using System.Collections.Generic;
using System.Linq;
using UrunYonetim6584.Entities.DTOs;

namespace UrunYonetimi6584.BL
{
    public class ProductManager : Repository<UrunYonetim6584.Entities.Product> // repository e product class ını gönderdik böylece ProductManager'ı kullandığımızda repository deki tüm metodlar product class ı için çalışacak.
    {
        public List<ProductListDto> GetProducts()
        {
            var products = context.Products.Include("Category") // veritabanından ürünleri içine kategorileri de dahil ederek çek
            .Select(x => new ProductListDto // db den gelen ürünlerden aşağıdaki alanları seç.
            {
                CategoryName = x.Category.Name,
                Brand = x.Brand,
                Name = x.Name,
                CreateDate = x.CreateDate,
                Id = x.Id,
                IsActive = x.IsActive,
                Price = x.Price,
                Stock = x.Stock
            }).ToList(); // seçtiğin verileri listele
            return products; // listeyi bu metodun kullanılacağı yere döndür.
        }
    }
}
