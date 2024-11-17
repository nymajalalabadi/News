using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Galleries
{
    public class CreateGalleryViewModel
    {
        [Display(Name = "نام گالری")]
        [MaxLength(300)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string GallryName { get; set; } = default!;

        [Display(Name = "توضیح مختصر")]
        [MaxLength(600)]
        public string? Description { get; set; }
    }

    public enum CreateGalleryResult
    {
        created,
        exists,
        error
    }
}
