using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Interfaces;

namespace News.Web.Components
{
    #region Sport ViewComponent

    [ViewComponent(Name = "SportViewComponent")]
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
            var data = await _reportService.GetReportsListForShowIndex("sport");

            return View("SportViewComponent", data);
        }

        #endregion
    }

    #endregion

    #region Economic

    [ViewComponent(Name = "EconomicViewComponent")]
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
            var data = await _reportService.GetReportsListForShowIndex("Economic");

            return View("EconomicViewComponent", data);
        }

        #endregion
    }

    #endregion

    #region Health

    [ViewComponent(Name = "HealthViewComponent")]
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
            var data = await _reportService.GetReportsListForShowIndex("Health");

            return View("HealthViewComponent", data);
        }

        #endregion
    }

    #endregion

    #region Multi Media

    [ViewComponent(Name = "MultiMediaSliderViewComponent")]
    public class MultiMediaSliderViewComponent : ViewComponent
    {
        #region consractor

        private readonly IReportService _reportService;

        public MultiMediaSliderViewComponent(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _reportService.GetReportsListForShowIndex("MultiMedia");

            return View("MultiMediaSliderViewComponent", data);
        }

        #endregion
    }

    #endregion

    #region Top Reports

    [ViewComponent(Name = "TopReportsViewComponent")]
    public class TopReportsViewComponent : ViewComponent
    {
        #region consractor

        private readonly IReportService _reportService;

        public TopReportsViewComponent(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _reportService.GetTopReportsForIndex("MultiMedia");

            return View("TopReportsViewComponent", data);
        }

        #endregion
    }

    #endregion

    #region Special Report

    [ViewComponent(Name = "SpecialReportViewComponent")]
    public class SpecialReportViewComponent : ViewComponent
    {
        #region consractor

        private readonly IReportService _reportService;

        public SpecialReportViewComponent(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _reportService.GetSpecialReportForIndex("Special");

            return View("SpecialReportViewComponent", data);
        }

        #endregion
    }

    #endregion

    #region Special Reports

    [ViewComponent(Name = "SpecialReportsViewComponent")]
    public class SpecialReportsViewComponent : ViewComponent
    {
        #region consractor

        private readonly IReportService _reportService;

        public SpecialReportsViewComponent(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _reportService.GetSpecialReportsForIndex("Special");

            return View("SpecialReportsViewComponent", data);
        }

        #endregion
    }

    #endregion

    #region Hot News Report

    [ViewComponent(Name = "HotNewsReportViewComponent")]
    public class HotNewsReportViewComponent : ViewComponent
    {
        #region consractor

        private readonly IReportService _reportService;

        public HotNewsReportViewComponent(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _reportService.GetHotNewsReportForIndex();

            return View("HotNewsReportViewComponent", data);
        }

        #endregion
    }

    #endregion

    #region Hot News reports

    [ViewComponent(Name = "HotNewsReportsViewComponent")]
    public class HotNewsReportsViewComponent : ViewComponent
    {
        #region consractor

        private readonly IReportService _reportService;

        public HotNewsReportsViewComponent(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _reportService.GetHotNewsReportsForIndex();

            return View("HotNewsReportsViewComponent", data);
        }

        #endregion
    }

    #endregion

    #region Last News reports

    [ViewComponent(Name = "LastNewsReportsViewComponent")]
    public class LastNewsReportsViewComponent : ViewComponent
    {
        #region consractor

        private readonly IReportService _reportService;

        public LastNewsReportsViewComponent(IReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _reportService.GetLastReportsForIndex();

            return View("LastNewsReportsViewComponent", data);
        }

        #endregion
    }

    #endregion

    #region Ads

    [ViewComponent(Name = "AdsViewComponent")]
    public class AdsViewComponent : ViewComponent
    {
        #region consractor

        private readonly IAdvertiseService _advertiseService;

        public AdsViewComponent(IAdvertiseService advertiseService)
        {
            _advertiseService = advertiseService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _advertiseService.GetAdvertisesForIndex();

            return View("AdsViewComponent", data);
        }

        #endregion
    }

    #endregion

    #region Side Gallery

    [ViewComponent(Name = "SideGalleryComponent")]
    public class SideGalleryComponent : ViewComponent
    {
        #region consractor

        private readonly IGalleryService _galleryService;

        public SideGalleryComponent(IGalleryService galleryServic)
        {
            _galleryService = galleryServic;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _galleryService.GetGalleriesForIndex();

            return View("SideGalleryComponent", data);
        }

        #endregion
    }

    #endregion
}
