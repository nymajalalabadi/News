using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Interfaces;
using News.Domain.ViewModels.Images;

namespace News.Web.Components
{
    [ViewComponent(Name = "SiteMenoViewComponent")]
    public class SiteMenoViewComponent : ViewComponent
    {
        #region consractor

        private readonly IGalleryService _galleryService;
        private readonly IReportService _reportService;

        public SiteMenoViewComponent(IGalleryService galleryService, IReportService reportService)
        {
            _galleryService = galleryService;
            _reportService = reportService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var imgesReportGroups = new ImagesAndReportGroupsViewModel()
            {
                Images = await _galleryService.GetImagesForIndex(),
                ReportGroups = await _reportService.GetReportGroupsForIndex()
            };

            return View("SiteMenoViewComponent", imgesReportGroups);
        }

        #endregion
    }
}
