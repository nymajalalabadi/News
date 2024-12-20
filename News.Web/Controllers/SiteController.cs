﻿using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Interfaces;
using News.Domain.ViewModels.Account;
using News.Domain.ViewModels.Reports;

namespace News.Web.Controllers
{
    public class SiteController : SiteBaseController
    {
        #region Consractor

        private readonly IReportService _reportService;

        private readonly IAccountService _accountService;

        private readonly IGalleryService _galleryService;


        public SiteController(IReportService reportService, IAccountService accountService, IGalleryService galleryService)
        {
            _reportService = reportService;
            _accountService = accountService;
            _galleryService = galleryService;
        }

        #endregion

        #region Methods

        #region Quick Access

        [HttpGet]
        public async Task<IActionResult> QuickAccess()
        {
            var reslut = await _reportService.GetAllReportGroupsForIndex();

            return View(reslut);
        }

        #endregion

        #region Archive

        [HttpGet]
        public async Task<IActionResult> Archive(FilterReportForShowViewModel filter)
        {
            filter.TakeEntity = 2;
            var reslut = await _reportService.GetFilterReportForIndex(filter);

            return View(reslut);
        }

        #endregion

        #region Most Viewed

        [HttpGet]
        public async Task<IActionResult> MostViewed(FilterReportsMostViewsViewModel filter)
        {
            var model = await _reportService.GetFilterReportsForMostViews(filter);
            return View(model);
        }

        #endregion

        #region Search

        [HttpGet]
        public async Task<IActionResult> Search(FilterReportsMostViewsViewModel filter)
        {
            var model = await _reportService.GetFilterReportsForMostViews(filter);

            return View(model);
        }

        #endregion

        #region Contact Us

        [HttpGet]
        public async Task<IActionResult> ContactUs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactUs(CreateContactUsViewModel create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }

            var reslut = await _accountService.CreateContactUs(create);

            switch (reslut)
            {
                case CreateContactUsReslut.Success:
                    TempData[SuccessMessage] = " تماس با ما جدید ساخته شد";
                    return RedirectToAction("/");
                case CreateContactUsReslut.Error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;
            }

            return View(create);
        }

        #endregion

        #region Gallery

        [HttpGet]
        public async Task<IActionResult> Galleries()
        {
            var model = await _galleryService.GetGalleriesForIndex();

            return View(model);
        }

        #endregion

        #region Gallery Images

        [HttpGet]
        public async Task<IActionResult> GalleryImages(long id, string GalleryName)
        {
            var model = await _galleryService.GetImagesByGroupId(id);
            ViewData["GalleryName"] = GalleryName;

            return View(model);
        }

        #endregion

        #endregion
    }
}
