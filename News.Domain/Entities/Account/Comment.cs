using News.Domain.Entities.Common;
using News.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.Entities.Account
{
    public class Comment : BaseEntity
    {
        #region properties

        [Display(Name = "صفحه خبر")]
        public long ReportId { get; set; }

        [Display(Name = "نام")]
        [MaxLength(50)]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Name { get; set; } = default!;

        [Display(Name = "ایمیل")]
        [MaxLength(50)]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Email { get; set; } = default!;

        [Display(Name = "نظر")]
        [MaxLength(800)]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string CommentText { get; set; } = default!;

        [Display(Name = "نمایش نظر")]
        public bool IsSuccess { get; set; }

        #endregion

        #region relations

        [Display(Name = "صفحه خبر")]
        public Report Report { get; set; }

        #endregion
    }
}
