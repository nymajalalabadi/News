using Microsoft.AspNetCore.Mvc;

namespace News.Web.Areas.Admin.Controllers
{
    public class ReportController : AdminBaseController
    {
        #region Consractor

        public ReportController()
        {
            
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
            return View();
        }

        #endregion

        #endregion
    }
}
