﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using News.Application.Services.Implementations;
using News.Application.Services.Interfaces;
using News.Domain.ViewModels.Account;
using News.Domain.ViewModels.Images;

namespace News.Web.Areas.Admin.Controllers
{
    public class AccountController : AdminBaseController
    {
        #region Consractor
         
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        #endregion

        #region Methods

        #region Comment

        #region Filter Comments Not Success

        [HttpGet]
        public async Task<IActionResult> FilterCommentsNotSuccess(FilterCommentViewModel filter)
        {
            var model = await _accountService.GetFilterCommentNotSuucess(filter);

            return View(model);
        }

        #endregion

        #region Filter Comments is Success

        [HttpGet]
        public async Task<IActionResult> FilterCommentsIsSuccess(FilterCommentViewModel filter)
        {
            var model = await _accountService.GetFilterCommentIsSuucess(filter);

            return View(model);
        }

        #endregion

        #region Delete Comment

        [HttpPost]
        public async Task<IActionResult> DeleteComment(long Id)
        {
            var result = await _accountService.DeleteComment(Id);

            if (!result)
            {
                return new JsonResult(new { status = "error", message = "مقادیر ورودی معتبر نمی باشد." });
            }

            return new JsonResult(new { status = "success", message = "عملیات با موفقیت انجام شد." });
        }

        #endregion

        #region Details Comment

        [HttpGet]
        public async Task<IActionResult> DetailsComment(long commentId)
        {
            var model = await _accountService.DetailsComment(commentId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        #endregion

        #region IsSuccess Comment

        [HttpPost]
        public async Task<IActionResult> IsSuccessComment(long Id)
        {
            var result = await _accountService.IsSuccessComment(Id);

            if (!result)
            {
                return new JsonResult(new { status = "error", message = "مقادیر ورودی معتبر نمی باشد." });
            }

            return new JsonResult(new { status = "success", message = "عملیات با موفقیت انجام شد." });
        }

        #endregion

        #endregion

        #region Contact us

        #region Show Contact us

        [HttpGet]
        public async Task<IActionResult> ShowContactus()
        {
            var model = await _accountService.GetContactUsForShow();

            return View(model);
        }

        #endregion

        #region Edit Or Create Contact us

        [HttpGet]
        public async Task<IActionResult> EditOrCreateContactus()
        {
            var model = await _accountService.GetCreateOrEditContactUsViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditOrCreateContactus(CreateOrEditContactUsViewModel createOrEdit)
        {
            if (!ModelState.IsValid)
            {
                return View(createOrEdit);
            }

            var reslut = await _accountService.CreateOrEditContactUs(createOrEdit);

            switch (reslut)
            {
                case EditContactUsReslut.Success:
                    TempData[SuccessMessage] = " تماس با ما جدید ساخته شد";
                    return RedirectToAction("ShowContactus");
                case EditContactUsReslut.Error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;
            }

            return View(createOrEdit);
        }

        #endregion

        #endregion

        #endregion
    }
}
