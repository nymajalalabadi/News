using Microsoft.AspNetCore.Mvc;
using News.Application.Services.Interfaces;

namespace News.Web.Components
{
    [ViewComponent(Name = "ReportCommentsComponent")]
    public class ReportCommentsComponent : ViewComponent
    {
        #region consractor

        private readonly IAccountService _accountService;

        public ReportCommentsComponent(IAccountService accountService)
        {
           _accountService = accountService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync(long reportId)
        {
            var data = await _accountService.AllReportCommentByreportId(reportId);

            return View("ReportCommentsComponent", data);
        }

        #endregion
    }
}
