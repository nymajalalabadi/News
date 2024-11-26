using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Images
{
    public class EditImageViewModel
    {
        public long ImageId { get; set; }

        public long GalleryId { get; set; }

        public string GalleryName { get; set; } = default!;

        [Display(Name = "نام تصویر")]
        [MaxLength(50)]
        public string ImageName { get; set; } = default!;

        [Display(Name = "عکس اصلی")]
        public IFormFile? AvatarImage { get; set; }
    }

    public enum EditImageResult
    {
        Success,
        HasNotItem
    }
}
