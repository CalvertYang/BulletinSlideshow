using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BulletinSlideshow.Models
{
    public class Parameter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "輪播間隔(毫秒)")]
        public int SlideInterval { get; set; }
    }
}