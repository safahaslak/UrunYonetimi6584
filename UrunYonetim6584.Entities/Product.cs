using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UrunYonetim6584.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; } // entityframework bu id değerini otomatik olarak primary key ve otomatik artan sayı olarak veritabanına ayarayacak.
        [StringLength(50), DisplayName ("Kategori Adı"), Required]
        public string Name { get; set; }
        [DisplayName ("Açıklama")]
        public string Description { get; set; }
        [StringLength(50)]
        [DisplayName ("Marka")]
        public string Brand { get; set; }
        [DisplayName ("Durum")]
        public bool IsActive { get; set; }
        [DisplayName ("Anaysafa")]
        public bool IsHome { get; set; }
        [DisplayName ("Stok")]
        public int Stock { get; set; }
        [DisplayName ("Ürün Fiyatı")]
        public decimal Price { get; set; }
        [StringLength(100)]
        [DisplayName ("Resim 1")]
        public string Image { get; set; }
        [StringLength(100)]
        [DisplayName ("Resim 2")]
        public string Image2 { get; set; }
        [DisplayName ("Eklenme Tarihi")]
        public DateTime CreateDate { get; set; }

        public int CategoryId { get; set; } // entity framework bu ilişkiye bakarak CategoryId propertysini foreignkey olarak işaretleyecek.
        public virtual Category Category { get; set; } // Product ile Caregory sınıfı arasında 1 e 1 ilişki kurduk. Yani her ürünün 1 kategorisi olacak.

    }
}
