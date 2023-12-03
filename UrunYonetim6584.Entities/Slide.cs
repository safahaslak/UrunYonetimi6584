using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunYonetim6584.Entities
{
    public class Slide : IEntity
    {
        public int Id { get; set; }
        [DisplayName("Eklenme Tarihi")]
        public DateTime CreateDate { get; set; } = DateTime.Now; // create date verilmişse onu al yoksa kaydettiğin date i yaz
        [DisplayName("Başlık"), StringLength(100)]
        public string Title { get; set; }
        [DisplayName("Açıklama"), StringLength(500)]
        public string Description { get; set; }
        [DisplayName("Resim"), StringLength(100)]
        public string Image { get; set; }
    }
}
