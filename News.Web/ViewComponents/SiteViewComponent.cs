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
            var data = await _reportService.GetReportsForIndex("sport");

            return View("SportViewComponent", data);
        }

        #endregion
    }

    #endregion

    #region Economic

    public class EconomicViewComponent : ViewComponent
    {
        #region consractor

        private readonly IReportService _reportService;

        public EconomicViewComponent(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _reportService.GetReportsForIndex("Economic");

            return View("EconomicViewComponent", data);
        }

        #endregion
    }
    #endregion

    #region Health

    public class HealthViewComponent : ViewComponent
    {
        #region consractor

        private readonly IReportService _reportService;

        public HealthViewComponent(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _reportService.GetReportsForIndex("Health");

            return View("HealthViewComponent", data);
        }

        #endregion
    }
    #endregion
}
