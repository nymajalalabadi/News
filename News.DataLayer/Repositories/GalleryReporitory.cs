using Microsoft.EntityFrameworkCore;
using News.DataLayer.Context;
using News.Domain.Entities.Galleries;
using News.Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataLayer.Repositories
{
    public class GalleryReporitory : IGalleryReporitory
    {
        #region Constructor

        private readonly NewsDbContext _context;

        public GalleryReporitory(NewsDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<IQueryable<Gallery>> GetGalleriesQuery()
        {
            return _context.Galleries
                .Where(g => !g.IsDelete)
                .AsQueryable();
        }

        public async Task<List<Gallery>> GetGalleriesForIndex()
        {
            return await _context.Galleries.Where(g => !g.IsDelete && g.IsSuccess).ToListAsync();
        }

        public async Task<Gallery?> GetGalleriesById(long id)
        {
            return await _context.Galleries.FirstOrDefaultAsync(g => g.Id.Equals(id));
        }

        public async Task<bool> IsExistGallryName(string gallryName)
        {
            return await _context.Galleries.AnyAsync(g => g.GallryName.Contains(gallryName));
        }

        public async Task AddGallery(Gallery gallery)
        {
            await _context.Galleries.AddAsync(gallery);
        }

        public void UpdateGallery(Gallery gallery)
        {
            _context.Galleries.Update(gallery);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
