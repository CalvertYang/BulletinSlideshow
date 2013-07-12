using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BulletinSlideshow.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "帳號")]
        [MaxLength(20)]
        [Remote("CheckAccountDuplicate", "Member", "Administrator", HttpMethod = "POST", ErrorMessage = "您輸入的帳號已被註冊了！", AdditionalFields = "Id")]
        public string Account { get; set; }

        [Required]
        [Display(Name = "密碼")]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "姓名")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Display(Name = "建立日期")]
        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CreateOn { get; set; }

        [Display(Name = "最後登入日期")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? LastLoginOn { get; set; }
    }
}