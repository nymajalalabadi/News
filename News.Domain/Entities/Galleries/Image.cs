using News.Domain.Entities.Common;
using News.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.Entities.Galleries
{
    public class Image : BaseEntity
    {
        #region properties

        public long Galleryid { get; set; }

        [Display(Name = "نام تصویر")]
        [MaxLength(50)]
        public string? ImageName { get; set; } = default!;

        [Display(Name = "وضعیت")]
        public bool IsSuccess { get; set; } = false;

        #endregion

        #region relations

        public Gallery Gallery { get; set; } = default!;

        #endregion
    }
}
