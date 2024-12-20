using News.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.Entities.Account
{
    public class Links : BaseEntity
    {
        [Display(Name = "نام لینک")]
        public string? LinkName { get; set; } = default!;
        [Display(Name = "آدرس لینک")]
        public string? LinkAddress { get; set; } = default!;

        [Display(Name = "وضعیت")]
        public bool IsSuccess { get; set; } = false;
    }
}
