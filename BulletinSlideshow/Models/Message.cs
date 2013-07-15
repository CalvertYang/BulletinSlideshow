using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BulletinSlideshow.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "即時訊息")]
        public string NotifyMessage { get; set; }

        [Display(Name = "最後編輯日期")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdateOn { get; set; }
    }
}