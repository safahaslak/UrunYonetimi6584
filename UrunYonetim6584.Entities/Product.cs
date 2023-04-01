﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunYonetim6584.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; } // entityframework bu id değerini otomatik olarak primary key ve otomatik artan sayı olarak veritabanına ayarayacak.
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public bool IsActive { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }

        public int CategoryId { get; set; } // entity framework bu ilişkiye bakarak CategoryId propertysini foreignkey olarak işaretleyecek.
        public virtual Category Category { get; set; } // Product ile Caregory sınıfı arasında 1 e 1 ilişki kurduk. Yani her ürünün 1 kategorisi olacak.

    }
}
