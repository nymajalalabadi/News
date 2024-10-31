﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.ReportGroups
{
    public class EditReportGroupViewModel
    {
        public long Id { get; set; }

        [Display(Name = "گروه خبری")]
        [Required(ErrorMessage = "نام {0} را وارد کنید")]
        [MaxLength(100)]
        public string GroupName { get; set; } = default!;

        [Display(Name = "تصویر گروه")]
        [MaxLength(100)]
        public string? GroupImage { get; set; } = default!;

        [Display(Name = "عکس اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public IFormFile? AvatarImage { get; set; }
    }

    public enum EditReportGroupResult
    {
        Success,
        Failure,
        HasNotItem
    }
}
