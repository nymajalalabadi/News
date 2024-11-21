using News.Application.Services.Interfaces;
using News.Domain.Entities.Galleries;
using News.Domain.InterFaces;
using News.Domain.ViewModels.Galleries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Services.Implementations
{
    public class GalleryService : IGalleryService
    {
        #region Constructor

        private readonly IGalleryReporitory _galleryReporitory;

        public GalleryService(IGalleryReporitory galleryReporitory)
        {
            _galleryReporitory = galleryReporitory;
        }

        #endregion

        #region gallery

        #region Methods

        public async Task<FilterGalleryViewModel> GetFilterGalleries(FilterGalleryViewModel filter)
        {
            var query = await _galleryReporitory.GetGalleriesQuery();

            #region Filter

            if (!string.IsNullOrEmpty(filter.GallryName))
            {
                query = query.Where(r => r.GallryName.Contains(filter.GallryName));
            }

            #endregion

            query = query.OrderByDescending(r => r.CreateDate);

            #region paging

            await filter.SetPaging(query);

            #endregion

            return filter;
        }

        public async Task<List<Gallery>> GetGalleriesForIndex()
        {
            return await _galleryReporitory.GetGalleriesForIndex();
        }

        public async Task<CreateGalleryResult> CreateGallery(CreateGalleryViewModel create)
        {
            if (create.GallryName == null)
            {
                return CreateGalleryResult.error;
            }

            if (await _galleryReporitory.IsExistGallryName(create.GallryName))
            {
                return CreateGalleryResult.exists;
            }

            var gallery = new Gallery()
            {
                GallryName = create.GallryName,
                Description = create.Description,
            };  

            await _galleryReporitory.AddGallery(gallery);
            await _galleryReporitory.SaveChanges();

            return CreateGalleryResult.created;
        }

        public async Task<EditGalleryViewModel> GetGalleryForEdit(long galleryId)
        {
            var gallery = await _galleryReporitory.GetGalleryById(galleryId);

            if (gallery == null)
            {
                return null;
            }

            return new EditGalleryViewModel()
            {
                GalleryId = galleryId,
                GallryName = gallery.GallryName,
                Description = gallery.Description,
            };
        }

        public async Task<EditGalleryResult> Editgallery(EditGalleryViewModel edit)
        {
            var gallery = await _galleryReporitory.GetGalleryById(edit.GalleryId);

            if (gallery == null)
            {
                return EditGalleryResult.NotFound;
            }

            if (await _galleryReporitory.IsExistGallryName(edit.GallryName))
            {
                return EditGalleryResult.NotFound;
            }

            gallery.GallryName = edit.GallryName;
            gallery.Description = edit.Description;

            _galleryReporitory.UpdateGallery(gallery);
            await _galleryReporitory.SaveChanges();

            return EditGalleryResult.success;
        }

        public async Task<DetailsGalleryViewModel> DetailsGallery(long galleryId)
        {
            var gallery = await _galleryReporitory.GetGalleryById(galleryId);

            if (gallery == null)
            {
                return null;
            }

            return new DetailsGalleryViewModel()
            {
                GallryName = gallery.GallryName,
                Description = gallery.Description,
            };
        }

        public async Task<bool> DeleteGallery(long galleryId)
        {
            var gallery = await _galleryReporitory.GetGalleryById(galleryId);

            if (gallery == null)
            {
                return false;
            }

            gallery.IsDelete = true;

            _galleryReporitory.UpdateGallery(gallery);
            await _galleryReporitory.SaveChanges();

            return true;
        }

        #endregion

        #endregion
    }
}
