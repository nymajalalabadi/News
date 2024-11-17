using News.Domain.Entities.Galleries;
using News.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Galleries
{
    public class FilterGalleryViewModel : Paging<Gallery>
    {
        public string? GallryName { get; set; } = default!;
    }
}
