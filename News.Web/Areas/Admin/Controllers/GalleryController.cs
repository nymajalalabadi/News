﻿using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Implementations;
using News.Application.Services.Interfaces;
using News.Domain.ViewModels.Galleries;
using News.Domain.ViewModels.Hashtags;

namespace News.Web.Areas.Admin.Controllers
{
    public class GalleryController : AdminBaseController
    {
        #region Consractor

        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        #endregion

        #region Gallery

        #region Filter gallery

        [HttpGet]
        public async Task<IActionResult> Filtergalleries(FilterGalleryViewModel filter)
        {
            var model = await _galleryService.GetFilterGalleries(filter);

            return View(model);
        }

        #endregion

        #region Create gallery

        [HttpGet]
        public async Task<IActionResult> CreateGallery()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGallery(CreateGalleryViewModel create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }

            var result = await _galleryService.CreateGallery(create);

            switch (result)
            {
                case CreateGalleryResult.created:
                    TempData[SuccessMessage] = " گالری جدید ساخته شد";
                    return RedirectToAction("Filtergalleries");
                case CreateGalleryResult.error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;
                case CreateGalleryResult.exists:
                    TempData[ErrorMessage] = "گالری قبلا انتخاب شده است ";
                    break;
            }

            return View(create);
        }

        #endregion

        #region Edit Gallery

        [HttpGet]
        public async Task<IActionResult> EditGallery(long galleryId)
        {
            var model = await _galleryService.GetGalleryForEdit(galleryId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditGallery(EditGalleryViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            var result = await _galleryService.Editgallery(edit);

            switch (result)
            {
                case EditGalleryResult.success:
                    TempData[SuccessMessage] = " گالری جدید ویرایش شد";
                    return RedirectToAction("Filtergalleries");
                case EditGalleryResult.NotFound:
                    TempData[ErrorMessage] = "گالری مورد نظر یافت نشد";
                    break;
            }

            return View(edit);
        }

        #endregion

        #region Details Gallery

        [HttpGet]
        public async Task<IActionResult> DetailsGallery(long galleryId)
        {
            var model = await _galleryService.DetailsGallery(galleryId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        #endregion

        #region Delete Gallery

        [HttpPost]
        public async Task<IActionResult> DeleteGallery(long Id)
        {
            var result = await _galleryService.DeleteGallery(Id);

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