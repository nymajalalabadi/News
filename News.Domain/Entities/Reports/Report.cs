using News.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace News.Domain.Entities.Reports
{
    public class Report : BaseEntity
    {
        #region properties

        public long ReportGroupId { get; set; }

        [Display(Name = "عنوان خبر")]
        [Required(ErrorMessage = "عنوان {0} را وارد کنید")]
        [MaxLength(100)]
        public string Title { get; set; } = default!;

        [Display(Name = "توضیح مختصر")]
        [MaxLength(1000)]
        public string? Description { get; set; } = default!;

        [Display(Name = "متن کامل")]
        public string? FullText { get; set; } = default!;

        [Display(Name = "تصویر خبر")]
        [MaxLength(100)]
        public string? Image { get; set; } = default!;

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

        [Display(Name = "بازدید")]
        public int? Visit { get; set; }

        [Display(Name = "اخبار داغ")]
        public bool IsHotNews { get; set; } = false;

        [Display(Name = "وضعیت")]
        public bool IsSuccess { get; set; } = false;

        [Display(Name = "زمان درج اخبار داغ")]
        public DateTime? HotNewsDate { get; set; } = default!;

        [Display(Name = "گروه خبری")]
        public int GroupId { get; set; } = default!;

        #endregion

        #region relations

        public ReportGroup ReportGroup { get; set; }

        #endregion
    }
}
