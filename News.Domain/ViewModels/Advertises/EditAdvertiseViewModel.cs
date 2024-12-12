using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Advertises
{
    public class EditAdvertiseViewModel
    {
        public long AdvertiseId { get; set; }

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
        public IFormFile? AvatarImage { get; set; }

        public string? Image { get; set; } = default!;
    }

    public enum EditAdvertiseResult
    {
        success,
        NotFound
    }
}
