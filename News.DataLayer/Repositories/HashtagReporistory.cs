using Microsoft.EntityFrameworkCore;
using News.DataLayer.Context;
using News.Domain.Entities.Hashtags;
using News.Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataLayer.Repositories
{
    public class HashtagReporistory : IHashtagReporistory
    {
        #region Constructor

        private readonly NewsDbContext _context;

        public HashtagReporistory(NewsDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<IQueryable<Hashtag>> GetHashtagsQuery()
        {
            return _context.Hashtags
                .Where(h => !h.IsDelete)
                .AsQueryable();
        }

        public async Task<Hashtag?> GetHashtagById(long id)
        {
            return await _context.Hashtags.FirstOrDefaultAsync(h => h.Id.Equals(id));
        }

        public async Task<bool> IsExistHashtagName(string hashtagName)
        {
            return await _context.Hashtags.AnyAsync(h => h.HashtagName.Equals(hashtagName));
        }

        public async Task AddHashtag(Hashtag hashtag)
        {
            await _context.Hashtags.AddAsync(hashtag);
        }

        public void UpdateHashtag(Hashtag hashtag)
        {
            hashtag.LastUpdateDate = DateTime.Now;
            _context.Hashtags.Update(hashtag);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
