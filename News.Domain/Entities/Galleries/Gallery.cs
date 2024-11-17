using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using News.Domain.Entities.Common;

namespace News.Domain.Entities.Galleries
{
    public class Gallery : BaseEntity
    {
        #region properties

        [Display(Name = "نام گالری")]
        [MaxLength(300)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string GallryName { get; set; } = default!;

        [Display(Name = "توضیح مختصر")]
        [MaxLength(600)]
        public string? Description { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsSuccess { get; set; } = false;

        #endregion
    }
}
