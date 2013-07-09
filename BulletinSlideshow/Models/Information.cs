using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BulletinSlideshow.Models
{
    public class Information
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "項目內容")]
        public string Content { get; set; }

        [ForeignKey("Category"), Display(Name = "項目分類")]
        public int CategoryId { get; set; }

        [Display(Name = "項目分類")]
        public Category Category { get; set; }

        [Display(Name = "建立日期"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateOn { get; set; }
    }
}