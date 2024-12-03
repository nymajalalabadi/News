using Microsoft.AspNetCore.Mvc;
using News.Application.Extensions;
using News.Application.Services.Interfaces;
using News.Domain.ViewModels.Account;
using News.Domain.ViewModels.ReportGroups;
using News.Domain.ViewModels.Reports;

namespace News.Web.Controllers
{
    public class ReportController : SiteBaseController
    {
        #region Consractor

        private readonly IReportService _reportService;

        private readonly IAccountService _accountService;

        public ReportController(IReportService reportService, IAccountService accountService)
        {
            _reportService = reportService;
            _accountService = accountService;
        }

        #endregion

        #region report

        #region Details Report

        [HttpGet]
        public async Task<IActionResult> Report(long reportId)
        {
            var model = await _reportService.GetReportForShowById(reportId);

            if (model == null)
            {
                return NotFound();
            }

            ViewData["RelatedReports"] = await _reportService.GetRelatedReportsForIndex(model.ReportGroup.UrlName, model.ReportId);

            return View(model);
        }

        #endregion

        #region Create Comment

        [HttpPost]
        public async Task<IActionResult> CreateReportComment(CreateCommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.CreateComment(comment);

                switch (result)
                {
                    case CreateCommentResult.CheckReport:
                        TempData[ErrorMessage] = "محصولی یافت نشد";
                        break;

                    case CreateCommentResult.Error:
                        TempData[ErrorMessage] = "ایمیل و اسم خود را وارد کنید";
                        break;

                    case CreateCommentResult.Success:
                        TempData[SuccessMessage] = "نظر شما با موفقیت ثبت شد";

                        return RedirectToAction("Report", new { productId = comment.ReportId });
                }
            }

            TempData[ErrorMessage] = "لطفا نظر خود را وارد نمایید";
            return RedirectToAction("Report", new { reportId = comment.ReportId });
        }

        #endregion

        #endregion

        #region report group

        [HttpGet]
        public async Task<IActionResult> ReportGroup(string urlName, FilterReportForShowViewModel filter)
        {
            var group = await _reportService.GetReportGroupByUrlName(urlName);

            filter.UrlName = group!.UrlName;
            filter.GroupName = group.GroupName;
            filter.TakeEntity = 1;
            var model = await _reportService.GetFilterReportForIndex(filter);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        #endregion

        #region Hot News report group

        [HttpGet]
        public async Task<IActionResult> HotNewsReportGroup(FilterHotNewsReportForShowViewModel filter)
        {
            filter.TakeEntity = 1;
            var model = await _reportService.GetFilterHotNewsReportForIndex(filter);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        #endregion
    }
}
