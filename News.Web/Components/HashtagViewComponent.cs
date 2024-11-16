using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Interfaces;

namespace News.Web.Components
{
    [ViewComponent(Name = "HashtagViewComponent")]
    public class HashtagViewComponent : ViewComponent
    {
        #region consractor

        private readonly IHashtagService _hashtagService;

        public HashtagViewComponent(IHashtagService hashtagService)
        {
            _hashtagService = hashtagService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _hashtagService.GetHashtagsForIndex();

            return View("HashtagViewComponent", data);
        }

        #endregion
    }
}
