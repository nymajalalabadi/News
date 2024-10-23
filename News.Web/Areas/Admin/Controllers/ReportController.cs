using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> FilterReports()
        {
            return View();
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
            return View();
        }

        #endregion

        #endregion
    }
}
