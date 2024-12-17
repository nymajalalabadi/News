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
            var reslut = await _reportService.GetFilterReportForIndex(filter);

            return View(reslut);
        }

        #endregion

        #endregion
    }
}
