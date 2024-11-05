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

    #region Cultural

    public class CulturalViewComponent : ViewComponent
    {
        #region consractor

        private readonly IReportService _reportService;

        public CulturalViewComponent(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _reportService.GetReportsForIndex("Cultural");

            return View("CulturalViewComponent", data);
        }

        #endregion

    }

    #endregion

    #region Political

    public class PoliticalViewComponent : ViewComponent
    {
        #region consractor

        private readonly IReportService _reportService;

        public PoliticalViewComponent(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _reportService.GetReportsForIndex("Political");

            return View("PoliticalViewComponent", data);
        }

        #endregion
    }

    #endregion

    #region Artistic

    public class ArtisticViewComponent : ViewComponent
    {
        #region consractor

        private readonly IReportService _reportService;

        public ArtisticViewComponent(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _reportService.GetReportsForIndex("Artistic");

            return View("ArtisticViewComponent", data);
        }

        #endregion
    }

    #endregion
}