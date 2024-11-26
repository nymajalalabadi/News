using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Galleries
{
    public class DetailsGalleryViewModel
    {
        [Display(Name = "نام گالری")]
        public string GallryName { get; set; } = default!;

        [Display(Name = "توضیح مختصر")]
        public string? Description { get; set; }

        public List<string> ImageNames { get; set; }
    }
}
