﻿using News.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Reports
{
    public class GetReportForShow
    {
        public long ReportId { get; set; }

        [Display(Name = "عنوان خبر")]
        [Required(ErrorMessage = "عنوان {0} را وارد کنید")]
        [MaxLength(100)]
        public string Title { get; set; } = default!;

        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "عنوان {0} را وارد کنید")]
        [MaxLength(1000)]
        public string Description { get; set; } = default!;

        [Display(Name = "متن کامل")]
        public string? FullText { get; set; } = default!;

        [Display(Name = "عکس")]
        public string Image { get; set; } = default!;

        [Display(Name = "توضیح تصویر")]
        [MaxLength(100)]
        public string? ImageAlt { get; set; } = default!;

        [Display(Name = "عنوان تصویر")]
        [MaxLength(100)]
        public string? ImageTitle { get; set; } = default!;

        [Display(Name = "منبع خبر")]
        [MaxLength(100)]
        public string? Source { get; set; } = default!;

        [Display(Name = "برچسب ها")]
        [MaxLength(500)]
        public string? Tags { get; set; } = default!;

        [Display(Name = "نویسنده خبر")]
        [MaxLength(100)]
        public string? Author { get; set; } = default!;

        [Display(Name = "اخبار داغ")]
        public bool IsHotNews { get; set; } = false;

        [Display(Name = "زمان درج اخبار داغ")]
        public DateTime? HotNewsDate { get; set; } = default!;

        public DateTime CreateDate { get; set; } = default!;

        public ReportGroup ReportGroup{ get; set; }
    }
}