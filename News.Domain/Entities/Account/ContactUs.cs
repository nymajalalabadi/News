using News.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.Entities.Account
{
    public class ContactUs : BaseEntity
    {
        #region properties

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        public string Name { get; set; } = default!;

        [Display(Name = "ایمیل")]
        [MaxLength(50)]
        public string? Email { get; set; } = default!;

        [Display(Name = "شماره تماس")]
        [MaxLength(20)]
        public string? PhoneNumber { get; set; } = default!;

        [Display(Name = "موضوع")]
        [MaxLength(250)]
        public string? Subject { get; set; } = default!;

        [Display(Name = "پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(1000)]
        public string Message { get; set; } = default!;

        #endregion
    }
}
