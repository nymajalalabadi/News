using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.ReportGroups
{
    public class CreateReportGroupViewModel
    {
        [Display(Name = "گروه خبری")]
        [Required(ErrorMessage = "نام {0} را وارد کنید")]
        [MaxLength(100)]
        public string GroupName { get; set; } = default!;

        [Display(Name = "عکس اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public IFormFile? AvatarImage { get; set; }
    }

    public enum CreateReportGroupResult
    {
        Success,
        Failure
    }
}
