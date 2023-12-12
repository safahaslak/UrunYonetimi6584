﻿  using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunYonetim6584.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), DisplayName("Kategori Adı"), Required]
        public string Name { get; set; }
        [DisplayName("Açıklama"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayName("Durum")]
        public bool IsActive { get; set; }
        [DisplayName("Kayıt Tarihi"), ScaffoldColumn(false)] //ScaffoldColumn(false) MVC de sayfa oluştururken bu alan ekranda oluşturulmasın demektir.
        public DateTime CreateDate { get; set; }

        public virtual List<Product> Products { get; set; } // burada Category ile Product classları arasında 1 e çok bir ilişki kurduk. Yani 1 kategorinin 1 den çok ürünü olabilir.
    }
}
