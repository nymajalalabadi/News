using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Interfaces;

namespace News.Web.ViewComponents
{
    #region Social

    public class SocialViewComponent : ViewComponent
    {
        #region consractor

        private readonly IReportService _reportService;

        public SocialViewComponent(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _reportService.GetReportsForIndex("Social");

            return View("SocialViewComponent", data);
        }

        #endregion
    }
    #endregion
}
