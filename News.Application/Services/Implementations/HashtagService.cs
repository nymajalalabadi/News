using News.Application.Services.Interfaces;
using News.Domain.Entities.Hashtags;
using News.Domain.InterFaces;
using News.Domain.ViewModels.Hashtags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Services.Implementations
{
    public class HashtagService : IHashtagService
    {
        #region Constructor

        private readonly IHashtagReporistory _hashtagReporistory;

        public HashtagService(IHashtagReporistory hashtagReporistory)
        {
            _hashtagReporistory = hashtagReporistory;
        }

        #endregion

        #region Methods

        public async Task<FilterHashtagsViewModel> GetFilterHashtagsGroups(FilterHashtagsViewModel filter)
        {
            var query = await _hashtagReporistory.GetHashtagsQuery();

            #region Filter

            if (!string.IsNullOrEmpty(filter.HashtagName))
            {
                query = query.Where(r => r.HashtagName.Contains(filter.HashtagName));
            }

            #endregion

            query = query.OrderByDescending(r => r.CreateDate);

            #region paging

            await filter.SetPaging(query);

            #endregion

            return filter;
        }

        public async Task<CreateHashtagResult> CreateHashtagGroup(CreateHashtagViewModel createHashtag)
        {
            if (createHashtag.HashtagName == null)
            {
                return CreateHashtagResult.error;
            }

            if (await _hashtagReporistory.IsExistHashtagName(createHashtag.HashtagName))
            {
                return CreateHashtagResult.exists;
            }

            var hashtag = new Hashtag()
            {
                HashtagName = createHashtag.HashtagName
            };

            await _hashtagReporistory.AddHashtag(hashtag);
            await _hashtagReporistory.SaveChanges();

            return CreateHashtagResult.created;
        }

        public async Task<EditHashtagViewModel> GetHashtagForEdit(long hashtagId)
        {
            var hashtag = await _hashtagReporistory.GetHashtagById(hashtagId);  

            if (hashtag == null)
            {
                return null;
            }

            return new EditHashtagViewModel()
            {
                HashtagId = hashtag.Id,
                HashtagName = hashtag.HashtagName
            };
        }

        public async Task<EditHashtagResult> EditHashtag(EditHashtagViewModel editHashtag)
        {
            var hashtag = await _hashtagReporistory.GetHashtagById(editHashtag.HashtagId);

            if (hashtag == null)
            {
                return EditHashtagResult.NotFound;
            }

            hashtag.HashtagName = editHashtag.HashtagName;

            _hashtagReporistory.UpdateHashtag(hashtag);
            await _hashtagReporistory.SaveChanges();

            return EditHashtagResult.success;
        }

        public async Task<DetailsHashtagViewModel> DetailsHashtag(long hashtagId)
        {
            var hashtag = await _hashtagReporistory.GetHashtagById(hashtagId);

            if (hashtag == null)
            {
                return null;
            }

            return new DetailsHashtagViewModel()
            {
                HashtagName = hashtag.HashtagName
            };
        }

        public async Task<bool> DeleteHashtag(long hashtagId)
        {
            var hashtag = await _hashtagReporistory.GetHashtagById(hashtagId);

            if (hashtag == null)
            {
                return false;
            }

            hashtag.IsDelete = true;

            _hashtagReporistory.UpdateHashtag(hashtag);
            await _hashtagReporistory.SaveChanges();

            return true;
        }

        #endregion
    }
}
