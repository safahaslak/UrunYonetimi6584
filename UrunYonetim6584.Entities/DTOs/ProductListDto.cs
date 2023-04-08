using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunYonetim6584.Entities.DTOs
{
    public class ProductListDto
    {
        public int Id { get; set; } 
        [StringLength(50), DisplayName("Ürün Adı"), Required]
        public string Name { get; set; }
        [StringLength(50)]
        [DisplayName("Marka")]
        public string Brand { get; set; }
        [DisplayName("Durum")]
        public bool IsActive { get; set; }
        [DisplayName("Stok")]
        public int Stock { get; set; }
        [DisplayName("Ürün Fiyatı")]
        public decimal Price { get; set; }
        [StringLength(100)]
        [DisplayName("Eklenme Tarihi")]
        public DateTime CreateDate { get; set; }
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }
    }
}
