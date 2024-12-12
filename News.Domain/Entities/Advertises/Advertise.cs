using News.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.Entities.Advertises
{
    public class Advertise : BaseEntity
    {
        [Display(Name = "نام شرکت / فرد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        public string? AdsName { get; set; } = default!;

        [Display(Name = "ایمیل")]
        [MaxLength(50)]
        public string? Email { get; set; } = default!;

        [Display(Name = "شماره تماس")]
        [MaxLength(20)]
        public string? PhoneNumber { get; set; } = default!;

        [Display(Name = "موضوع")]
        [MaxLength(150)]
        public string? Subject { get; set; } = default!;

        [Display(Name = "هزینه")]
        public int? price { get; set; } = default!;

        [Display(Name = "تاریخ انقضاء")]
        public DateTime? ExpireDate { get; set; } = default!;

        [Display(Name = "تصویر تبلیغ")]
        [MaxLength(200)]
        public string? Image { get; set; } = default!;

    }
}
