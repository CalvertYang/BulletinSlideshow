using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BulletinSlideshow.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "專案名稱")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "現狀")]
        public string Situation { get; set; }

        [Required]
        [Display(Name = "方案")]
        public string Plan { get; set; }

        [Required]
        [Display(Name = "負責人")]
        public string Director { get; set; }

        [Display(Name = "預計解決日期")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpectSolveDate { get; set; }

        [Display(Name = "建立日期")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CreateOn { get; set; }

        [Display(Name = "最後更新日期")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdateOn { get; set; }
    }
}