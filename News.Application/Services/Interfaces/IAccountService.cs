using News.Domain.Entities.Account;
using News.Domain.ViewModels.Account;
using News.Domain.ViewModels.ReportGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Services.Interfaces
{
    public interface IAccountService
    {
        #region Methods

        #region Comment

        Task<FilterCommentViewModel> GetFilterCommentNotSuucess(FilterCommentViewModel filter);

        Task<FilterCommentViewModel> GetFilterCommentIsSuucess(FilterCommentViewModel filter);

        Task<List<Comment>> GetCommentsForIndex();

        Task<List<Comment>> AllReportCommentByreportId(long reportId);

        Task<CreateCommentResult> CreateComment(CreateCommentViewModel create);

        Task<DetailsCommentViewModel> DetailsComment(long commentId);

        Task<bool> DeleteComment(long commentId);

        Task<bool> IsSuccessComment(long commentId);

        #endregion

        #endregion
    }
}
