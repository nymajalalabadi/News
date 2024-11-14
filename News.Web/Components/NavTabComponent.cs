using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Interfaces;

namespace News.Web.Components
{
    #region Social

    [ViewComponent(Name = "SocialViewComponent")]
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

    [ViewComponent(Name = "CulturalViewComponent")]
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

    [ViewComponent(Name = "PoliticalViewComponent")]
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

    [ViewComponent(Name = "ArtisticViewComponent")]
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