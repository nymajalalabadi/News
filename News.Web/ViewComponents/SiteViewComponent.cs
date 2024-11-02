using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Interfaces;

namespace News.Web.ViewComponents
{
    #region Sport ViewComponent

    public class SportViewComponent : ViewComponent
    {
        #region consractor

        private readonly IReportService _reportService;

        public SportViewComponent(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _reportService.GetReportsForVrazesh("sport");

            return View("SportViewComponent", data);
        }

        #endregion
    }

    #endregion
}
