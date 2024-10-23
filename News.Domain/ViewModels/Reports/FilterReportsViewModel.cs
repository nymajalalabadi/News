using News.Domain.Entities.Reports;
using News.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Reports
{
    public class FilterReportsViewModel : Paging<Report>
    {
        public string? Title { get; set; } = default!;

        public FilterReportsState FilterReportsState { get; set; }
    }

    public enum FilterReportsState
    {
        [Display(Name = "همه")]
        All,
        [Display(Name = "اخبار معمولی")]
        Normal,
        [Display(Name = "اخبار مهم")]
        IsHotNews,
        [Display(Name = "اخبار با موفقیت ثبت شده")]
        IsSuccess,
        [Display(Name = "اخبار با موفقیت ثبت نشده")]
        IsNotSuccess,
    }
}
