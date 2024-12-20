using Microsoft.AspNetCore.Mvc.Rendering;
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

        #region gallery

        #region Methods

        public async Task<IQueryable<Gallery>> GetGalleriesQuery()
        {
            return _context.Galleries
                .Include(g => g.Images)
                .Where(g => !g.IsDelete)
                .AsQueryable();
        }

        public async Task<List<Gallery>> GetGalleriesForIndex()
        {
            return await _context.Galleries.Where(g => !g.IsDelete && g.IsSuccess).ToListAsync();
        }

        public async Task<List<SelectListItem>> SelectedGalleryId()
        {
            return await _context.Galleries
                .Where(p => !p.IsDelete && p.IsSuccess)
                .Select(p => new SelectListItem()
                {
                    Text = p.GallryName,
                    Value = p.Id.ToString()
                })
                .ToListAsync();
        }

        public async Task<Gallery?> GetGalleryById(long id)
        {
            return await _context.Galleries.Include(g => g.Images).FirstOrDefaultAsync(g => g.Id.Equals(id));
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


        #endregion

        #region Image

        #region Methods

        public async Task<IQueryable<Image>> GetImagesQuery()
        {
            return _context.Images
                .Include(i => i.Gallery)
                .Where(i => !i.IsDelete)
                .AsQueryable();
        }

        public async Task<List<Image>> GetImagesForIndex()
        {
            return  await _context.Images
                .Include(i => i.Gallery)
                .Where(i => !i.IsDelete && i.IsSuccess)
                .OrderByDescending(i => i.CreateDate)
                .Take(10)
                .ToListAsync(); 
        }

        public async Task<List<Image>> GetImagesByGroupId(long groupId)
        {
            return await _context.Images
                .Include(i => i.Gallery)
                .Where(i => !i.IsDelete && i.IsSuccess && i.GalleryId.Equals(groupId))
                .OrderByDescending(i => i.CreateDate)
                .ToListAsync();
        }

        public async Task<Image?> GetImageyById(long id)
        {
            return await _context.Images.Include(i => i.Gallery).FirstOrDefaultAsync(i => i.Id.Equals(id));
        }

        public async Task AddImage(Image image)
        {
            await _context.Images.AddAsync(image);
        }

        public void UpdateImage(Image image)
        {
            _context.Images.Update(image);
        }

        #endregion

        #endregion
    }
}
