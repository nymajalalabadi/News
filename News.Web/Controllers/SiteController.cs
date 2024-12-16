using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Interfaces;

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

        [HttpGet]
        public async Task<IActionResult> QuickAccess()
        {
            var reslut = await _reportService.GetAllReportGroupsForIndex();

            return View(reslut);
        }

        #endregion
    }
}
