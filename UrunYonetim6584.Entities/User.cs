﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UrunYonetim6584.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), Display(Name = "Adı"), Required]
        public string Name { get; set; }
        [StringLength(50), Display(Name = "Soyadı")]
        public string Surname { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50), Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }
        [StringLength(50), Display(Name = "Şifre")]
        public string Password { get; set; }
        [StringLength(50), Display(Name = "Telefon")]
        public string Phone { get; set; }
        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set;}
        [Display(Name = "Kayıt Tarihi?")]
        public DateTime CreateDate { get; set; }
    }
}
