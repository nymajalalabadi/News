using Microsoft.AspNetCore.Mvc;
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

        #region Filter Comments

        [HttpGet]
        public async Task<IActionResult> FilterComments(FilterCommentViewModel filter)
        {
            var model = await _accountService.GetFilterComments(filter);

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

        #endregion
    }
}
