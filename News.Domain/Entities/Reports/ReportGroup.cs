using News.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.Entities.Reports
{
    public class ReportGroup : BaseEntity
    {
        #region properties

        [Display(Name = "گروه خبری")]
        [Required(ErrorMessage = "نام {0} را وارد کنید")]
        [MaxLength(100)]
        public string GroupName { get; set; } = default!;

        [Display(Name = "تصویر گروه")]
        [MaxLength(100)]
        public string? GroupImage { get; set; } = default!;

        #endregion

        #region relations

        public ICollection<Report> Reports { get; set; } = default!;

        #endregion
    }
}
