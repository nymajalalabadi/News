using Microsoft.AspNetCore.Mvc;

namespace News.Web.Areas.Admin.Components
{
    public class LeftSideBarViewComponent : ViewComponent
    {
        #region Constructor

        public LeftSideBarViewComponent()
        {
        }

        #endregion

        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("LeftSideBar");
        }

        #endregion
    }
}
