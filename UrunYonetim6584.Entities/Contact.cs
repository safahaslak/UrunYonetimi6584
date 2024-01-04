using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunYonetim6584.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; } 
        [StringLength(50), DisplayName("Müşteri Adı"), Required]
        public string Name { get; set; }
        [DisplayName("Müşteri Soyadı")]
        public string Surname { get; set; }
        [DisplayName("Müşteri Telefonu"), Required]
        public int Telephone { get; set; }
        [StringLength(50), DisplayName("Email"), Required]
        public string Email { get; set; }
        [StringLength(1000), DisplayName("Mesaj"), Required]
        public string Message { get; set; }
        [DisplayName("Müşteri Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        
    }
}
