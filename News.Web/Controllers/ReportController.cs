using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Interfaces;
using News.Domain.ViewModels.ReportGroups;
using News.Domain.ViewModels.Reports;

namespace News.Web.Controllers
{
    public class ReportController : Controller
    {
        #region Consractor

        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region report

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
