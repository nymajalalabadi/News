using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Hashtags
{
    public class EditHashtagViewModel
    {
        public long HashtagId { get; set; }

        [Display(Name = "هشتگ")]
        [MaxLength(50)]
        public string HashtagName { get; set; } = default!;
    }

    public enum EditHashtagResult
    {
        success,
        NotFound
    }
}
