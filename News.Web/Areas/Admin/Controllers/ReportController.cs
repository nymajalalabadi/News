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

        public async Task<IActionResult> FilterReports()
        {
            return View();
        }

        #endregion
    }
}
