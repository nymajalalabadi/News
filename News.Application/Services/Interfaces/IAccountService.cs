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

        Task<FilterCommentViewModel> GetFilterComments(FilterCommentViewModel filter);

        Task<CreateCommentResult> CreateComment(CreateCommentViewModel create);

        Task<DetailsCommentViewModel> DetailsComment(long commentId);

        #endregion

        #endregion
    }
}
