using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Implementations;
using News.Application.Services.Interfaces;
using News.Domain.ViewModels.Hashtags;
using News.Domain.ViewModels.ReportGroups;

namespace News.Web.Areas.Admin.Controllers
{
    public class HashtagController : AdminBaseController
    {
        #region Consractor

        private readonly IHashtagService _hashtagService;

        public HashtagController(IHashtagService hashtagService)
        {
            _hashtagService = hashtagService;
        }

        #endregion

        #region Hashtag

        #region Filter hashtag

        [HttpGet]
        public async Task<IActionResult> FilterHashtags(FilterHashtagsViewModel filter)
        {
            var model = await _hashtagService.GetFilterHashtagsGroups(filter);

            return View(model);
        }

        #endregion

        #region Create Hashtag

        [HttpGet]
        public async Task<IActionResult> CreateHashtag()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHashtag(CreateHashtagViewModel hashatg)
        {
            if (!ModelState.IsValid)
            {
                return View(hashatg);
            }

            var result = await _hashtagService.CreateHashtagGroup(hashatg);

            switch (result)
            {
                case CreateHashtagResult.created:
                    TempData[SuccessMessage] = " هشتگ جدید ساخته شد";
                    return RedirectToAction("FilterHashtags");
                case CreateHashtagResult.error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;
                case CreateHashtagResult.exists:
                    TempData[ErrorMessage] = "هشتگ قبلا انتخاب شده است ";
                    break;
            }

            return View(hashatg);
        }

        #endregion

        #region Edit Hashtag

        [HttpGet]
        public async Task<IActionResult> EditHashtag(long hashtagId)
        {
            var model = await _hashtagService.GetHashtagForEdit(hashtagId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditHashtag(EditHashtagViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            var result = await _hashtagService.EditHashtag(edit);

            switch (result)
            {
                case EditHashtagResult.success:
                    TempData[SuccessMessage] = " هشتگ جدید ویرایش شد";
                    return RedirectToAction("FilterHashtags");
                case EditHashtagResult.NotFound:
                    TempData[ErrorMessage] = "هشتگ مورد نظر یافت نشد";
                    break;
            }

            return View(edit);
        }

        #endregion

        #region Details Hashtag

        [HttpGet]
        public async Task<IActionResult> DetailsHashtag(long hashtagId)
        {
            var model = await _hashtagService.DetailsHashtag(hashtagId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        #endregion

        #region Delete Hashtag

        [HttpPost]
        public async Task<IActionResult> DeleteHashtag(long Id)
        {
            var result = await _hashtagService.DeleteHashtag(Id);

            if (!result)
            {
                return new JsonResult(new { status = "error", message = "مقادیر ورودی معتبر نمی باشد." });
            }

            return new JsonResult(new { status = "success", message = "عملیات با موفقیت انجام شد." });
        }

        #endregion

        #endregion
    }
}
