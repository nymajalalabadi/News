using News.Domain.Entities.Hashtags;
using News.Domain.ViewModels.Hashtags;
using News.Domain.ViewModels.ReportGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Services.Interfaces
{
    public interface IHashtagService
    {
        #region Methods

        Task<FilterHashtagsViewModel> GetFilterHashtagsGroups(FilterHashtagsViewModel filter);

        Task<List<Hashtag>> GetHashtagsForIndex();

        Task<CreateHashtagResult> CreateHashtagGroup(CreateHashtagViewModel createHashtag);

        Task<EditHashtagViewModel> GetHashtagForEdit(long hashtagId);

        Task<EditHashtagResult> EditHashtag(EditHashtagViewModel editHashtag);

        Task<DetailsHashtagViewModel> DetailsHashtag(long hashtagId);

        Task<bool> DeleteHashtag(long hashtagId);

        #endregion
    }
}
