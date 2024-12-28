using News.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace News.Domain.Entities.Account
{
    public class Users : BaseEntity
    {
        [Display(Name = "نام کاربری")]
        public string? UserName { get; set; }

        [MaxLength(50)]
        [Display(Name = "نام")]
        public string? Name { get; set; }

        [MaxLength(50)]
        [Display(Name = " نام خانوادگی")]
        public string? Familly { get; set; }

        [MaxLength(50)]
        [Display(Name = "شماره همراه")]
        public string? PhoneNumber { get; set; }

        [MaxLength(50)]
        [Display(Name = "عکس پروفایل")]
        public string? ProfileImage { get; set; }

        [MaxLength(50)]
        [Display(Name = "نقش کاربر")]
        public string? InRole { get; set; }
    }
}
