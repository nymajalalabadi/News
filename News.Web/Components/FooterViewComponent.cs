using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Interfaces;
using News.Domain.ViewModels.Footer;

namespace News.Web.Components
{
    [ViewComponent(Name = "FooterViewComponent")]
    public class FooterViewComponent : ViewComponent
    {
        #region consractor

        private readonly IGalleryService _galleryService;
        private readonly IReportService _reportService;
        private readonly IAccountService _accountService;

        public FooterViewComponent(IGalleryService galleryService, IReportService reportService, IAccountService accountService)
        {
            _galleryService = galleryService;
            _reportService = reportService;
            _accountService = accountService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footer = new FooterViewModel()
            {
                Images = await _galleryService.GetImagesForIndex(),
                Reports = await _reportService.GetReportsForFooter(),
                Comments = await _accountService.GetCommentsForIndex()
            };

            return View("FooterViewComponent", footer);
        }

        #endregion
    }
}
