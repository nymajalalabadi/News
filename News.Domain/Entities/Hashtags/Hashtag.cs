using News.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.Entities.Hashtags
{
    public class Hashtag : BaseEntity
    {
        [MaxLength(50)]
        [Display(Name = "هشتگ")]
        public string HashtagName { get; set; } = default!;
    }
}
