using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Logging;
using News.Application.Services.Interfaces;
using News.Domain.ViewModels.ReportGroups;
using News.Domain.ViewModels.Reports;
using System.Text.RegularExpressions;

namespace News.Web.Areas.Admin.Controllers
{
    public class ReportController : AdminBaseController
    {
        #region Consractor

        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region report Group

        #region Filter Report Group

        [HttpGet]
        public async Task<IActionResult> FilterReportGroups(FilterReportGroupsViewModel filter)
        {
            var model = await _reportService.GetFilterReportGroups(filter);

            return View(model);
        }

        #endregion

        #region Create Report Group

        [HttpGet]
        public async Task<IActionResult> CreateReportGroup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReportGroup(CreateReportGroupViewModel reportGroup)
        {
            if (!ModelState.IsValid)
            {
                return View(reportGroup);
            }

            var result = await _reportService.CreateReportGroup(reportGroup);

            switch (result)
            {
                case CreateReportGroupResult.Success:
                    TempData[SuccessMessage] = "گروه خبری جدید ساخته شد";
                    return RedirectToAction("FilterReportGroups");
                case CreateReportGroupResult.Failure:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;
                case CreateReportGroupResult.IsExistUrlName:
                    TempData[ErrorMessage] = "urlName قبلا انتخاب شده است ";
                    break;
            }

            return View(reportGroup);
        }

        #endregion

        #region Edit Report Group

        [HttpGet]
        public async Task<IActionResult> EditReportGroup(long reportGroupId)
        {
            var model = await _reportService.GetReportGroupForEdit(reportGroupId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditReportGroup(EditReportGroupViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            var result = await _reportService.EditReportGroup(edit);

            switch (result)
            {
                case EditReportGroupResult.Success:
                    TempData[SuccessMessage] = "گروه خبری جدید ویرایش شد";
                    return RedirectToAction("FilterReportGroups");
                case EditReportGroupResult.Failure:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;
                case EditReportGroupResult.HasNotItem:
                    TempData[ErrorMessage] = "گروه خبری مورد نظر یافت نشد";
                    break;
            }

            return View(edit);
        }

        #endregion

        #region Details Report Group

        [HttpGet]
        public async Task<IActionResult> DetailsReportGroup(long reportGroupId)
        {
            var model = await _reportService.DetailsReportGroup(reportGroupId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        #endregion

        #region Delete Report Group

        [HttpPost]
        public async Task<IActionResult> DeleteReportGroup(long Id)
        {
            var result = await _reportService.DeleteReportGroup(Id);

            if (!result)
            {
                return new JsonResult(new { status = "error", message = "مقادیر ورودی معتبر نمی باشد."});
            }

            return new JsonResult(new { status = "success", message = "عملیات با موفقیت انجام شد."});
        }

        #endregion

        #endregion

        #region report

        #region Filter Reports

        [HttpGet]
        public async Task<IActionResult> FilterReports(FilterReportsViewModel filter)
        {
            var model = await _reportService.GetFilterReports(filter);

            return View(model);
        }

        #endregion

        #region Create Report

        [HttpGet]
        public async Task<IActionResult> CreateReport()
        {
            var groupReports = await _reportService.SelectedReportGroupId();
            ViewData["reportGroup"] = new SelectList(groupReports, "Value", "Text");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport(CreateReportViewModel report)
        {
            if (!ModelState.IsValid)
            {
                ViewData["reportGroup"] = await _reportService.SelectedReportGroupId();
                return View(report);
            }

            var result = await _reportService.CreateReport(report);

            switch (result)
            {
                case CreateReportResult.Success:
                    TempData[SuccessMessage] = "گزارش جدید ساخته شد";
                    return RedirectToAction("FilterReports");
                case CreateReportResult.Error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;
                case CreateReportResult.NoImage:
                    TempData[ErrorMessage] = "لطفا عکس انخاب کنید";
                    break;
            }

            ViewData["reportGroup"] = await _reportService.SelectedReportGroupId();
            return View(report);
        }

        #endregion

        #region Edit Report

        [HttpGet]
        public async Task<IActionResult> EditReport(long reportId)
        {
            var model = await _reportService.GetReportForEdit(reportId);

            if (model == null)
            {
                return NotFound();
            }

            var groupReports = await _reportService.SelectedReportGroupId();
            ViewData["reportGroup"] = new SelectList(groupReports, "Value", "Text", model.GroupId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditReport(EditReportViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                var groupReports = await _reportService.SelectedReportGroupId();
                ViewData["reportGroup"] = new SelectList(groupReports, "Value", "Text", edit.GroupId);

                return View(edit);
            }

            var result = await _reportService.EditReport(edit);

            switch (result)
            {
                case EditReportResult.Success:
                    TempData[SuccessMessage] = "گزارش جدید ساخته شد";
                    return RedirectToAction("FilterReports");
                case EditReportResult.Error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;
                case EditReportResult.HasNotItem:
                    TempData[ErrorMessage] = "گزارش مورد نظر یافت نشد";
                    break;
            }

            var groupReportss = await _reportService.SelectedReportGroupId();
            ViewData["reportGroup"] = new SelectList(groupReportss, "Value", "Text", edit.GroupId);

            return View(edit);
        }

        #endregion

        #region Details Report

        [HttpGet]
        public async Task<IActionResult> DetailsReport(long reportId)
        {
            var model = await _reportService.DetailsReport(reportId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        #endregion

        #region Delete Report

        [HttpPost]
        public async Task<IActionResult> DeleteReport(long Id)
        {
            var result = await _reportService.DeleteReport(Id);

            if (!result)
            {
                return new JsonResult(new { status = "error", message = "مقادیر ورودی معتبر نمی باشد." });
            }

            return new JsonResult(new { status = "success", message = "عملیات با موفقیت انجام شد." });
        }

        #endregion

        #region Hot Report

        [HttpPost]
        public async Task<IActionResult> HotReport(long Id)
        {
            var result = await _reportService.HotReport(Id);

            if (!result)
            {
                return new JsonResult(new { status = "error", message = "مقادیر ورودی معتبر نمی باشد." });
            }

            return new JsonResult(new { status = "success", message = "عملیات با موفقیت انجام شد." });
        }

        #endregion


        #endregion
    }
}
