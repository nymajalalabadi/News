using News.Domain.Entities.Galleries;
using News.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Images
{
    public class FilterImagesViewModel : Paging<Image>
    {
        public string? ImageName { get; set; } = default!;
    }
}
