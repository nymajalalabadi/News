using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Interfaces;

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

        public async Task<IActionResult> Report(long reportId)
        {
            var model = await _reportService.GetReportForShowById(reportId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}
