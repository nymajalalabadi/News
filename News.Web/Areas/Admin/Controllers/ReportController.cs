using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using News.Application.Services.Interfaces;
using News.Domain.ViewModels.Reports;

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


        #region report

        #region Filter Reports

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
            ViewData["reportGroup"] = await _reportService.SelectedReportGroupId();

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

        #region Details

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

        #endregion
    }
}
