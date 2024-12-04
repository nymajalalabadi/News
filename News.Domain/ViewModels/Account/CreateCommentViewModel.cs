using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Account
{
    public class CreateCommentViewModel
    {
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
    }

    public enum CreateCommentResult
    {
        Success,
        Error,
        CheckReport
    }
}
