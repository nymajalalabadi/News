using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Implementations;
using News.Application.Services.Interfaces;
using News.Domain.ViewModels.Advertises;
using News.Domain.ViewModels.Hashtags;

namespace News.Web.Areas.Admin.Controllers
{
    public class AdvertiseController : AdminBaseController
    {
        #region Consractor

        private readonly IAdvertiseService _advertiseService;

        public AdvertiseController(IAdvertiseService advertiseService)
        {
            _advertiseService = advertiseService;
        }

        #endregion


        #region Advertise

        #region Filter Advertise

        [HttpGet]
        public async Task<IActionResult> FilterAdvertises(FilterAdvertisesViewModel filter)
        {
            var model = await _advertiseService.GetFilterAdvertisesGroups(filter);

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
        public async Task<IActionResult> CreateAdvertise(CreateAdvertiseViewModel hashatg)
        {
            if (!ModelState.IsValid)
            {
                return View(hashatg);
            }

            var result = await _advertiseService.CreateAdvertiseGroup(hashatg);

            switch (result)
            {
                case CreateAdvertiseResult.created:
                    TempData[SuccessMessage] = " تبلیغ جدید ساخته شد";
                    return RedirectToAction("FilterAdvertises");
                case CreateAdvertiseResult.error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;
            }

            return View(hashatg);
        }

        #endregion

        #region Edit Advertise

        [HttpGet]
        public async Task<IActionResult> EditAdvertise(long advertiseId)
        {
            var model = await _advertiseService.GetAdvertiseForEdit(advertiseId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAdvertise(EditAdvertiseViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            var result = await _advertiseService.EditAdvertise(edit);

            switch (result)
            {
                case EditAdvertiseResult.success:
                    TempData[SuccessMessage] = " تبلیغ جدید ویرایش شد";
                    return RedirectToAction("FilterHashtags");
                case EditAdvertiseResult.NotFound:
                    TempData[ErrorMessage] = "تبلیغ مورد نظر یافت نشد";
                    break;
            }

            return View(edit);
        }

        #endregion

        #region Details Advertise

        [HttpGet]
        public async Task<IActionResult> DetailsAdvertise(long advertiseId)
        {
            var model = await _advertiseService.DetailsAdvertise(advertiseId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        #endregion

        #region Delete Advertise

        [HttpPost]
        public async Task<IActionResult> DeleteAdvertise(long Id)
        {
            var result = await _advertiseService.DeleteAdvertise(Id);

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
