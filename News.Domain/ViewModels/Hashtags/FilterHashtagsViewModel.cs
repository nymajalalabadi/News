using News.Domain.Entities.Hashtags;
using News.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Hashtags
{
    public class FilterHashtagsViewModel : Paging<Hashtag>
    {
        public string? HashtagName { get; set; } = default!;
    }
}
