using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Interfaces;

namespace News.Web.Components
{
    [ViewComponent(Name = "SiteMenoViewComponent")]
    public class SiteMenoViewComponent : ViewComponent
    {
        #region consractor

        private readonly IGalleryService _galleryService;

        public SiteMenoViewComponent(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var gallery = await _galleryService.GetGalleriesForIndex();

            return View("SiteMenoViewComponent", gallery);
        }

        #endregion
    }
}
