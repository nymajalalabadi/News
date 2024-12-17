using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Interfaces;
using News.Domain.ViewModels.Reports;

namespace News.Web.Controllers
{
    public class SiteController : SiteBaseController
    {
        #region Consractor

        private readonly IReportService _reportService;

        public SiteController(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region Methods

        #region Quick Access

        [HttpGet]
        public async Task<IActionResult> QuickAccess()
        {
            var reslut = await _reportService.GetAllReportGroupsForIndex();

            return View(reslut);
        }

        #endregion

        #region Archive

        [HttpGet]
        public async Task<IActionResult> Archive(FilterReportForShowViewModel filter)
        {
            filter.TakeEntity = 2;
            var reslut = await _reportService.GetFilterReportForIndex(filter);

            return View(reslut);
        }

        #endregion

        #region Most Viewed

        [HttpGet]
        public async Task<IActionResult> MostViewed(FilterReportsMostViewsViewModel filter)
        {
            var model = await _reportService.GetFilterReportsForMostViews(filter);
            return View(model);
        }

        #endregion

        #region Search

        [HttpGet]
        public async Task<IActionResult> Search(FilterReportsMostViewsViewModel filter)
        {
            var model = await _reportService.GetFilterReportsForMostViews(filter);

            return View(model);
        }

        #endregion

        #endregion
    }
}
