using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BulletinSlideshow.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "分類名稱"), MaxLength(50)]
        public string Name { get; set; }
    }
}