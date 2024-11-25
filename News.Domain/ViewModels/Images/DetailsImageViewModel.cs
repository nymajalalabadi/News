using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Images
{
    public class DetailsImageViewModel
    {
        [Display(Name = "نام تصویر")]
        [MaxLength(50)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ImageName { get; set; } = default!;

        [Display(Name = "وضعیت")]
        public bool IsSuccess { get; set; } = false;

        public string GalleryName { get; set; } = default!;
    }
}
