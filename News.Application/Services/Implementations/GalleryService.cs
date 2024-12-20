using Microsoft.AspNetCore.Mvc.Rendering;
using News.Application.Generators;
using News.Application.Services.Interfaces;
using News.Application.Statics;
using News.Domain.Entities.Galleries;
using News.Domain.InterFaces;
using News.Domain.ViewModels.Galleries;
using News.Domain.ViewModels.Images;

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

        public async Task<List<SelectListItem>> SelectedGalleryId()
        {
            return await _galleryReporitory.SelectedGalleryId();    
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
                IsSuccess = true
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
                ImageNames = gallery.Images.Select(r => r.ImageName).ToList(),
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

        #region image

        #region Methods

        public async Task<FilterImagesViewModel> GetFilterImages(FilterImagesViewModel filter)
        {
            var query = await _galleryReporitory.GetImagesQuery();

            #region Filter

            if (!string.IsNullOrEmpty(filter.ImageName))
            {
                query = query.Where(r => r.ImageName.Contains(filter.ImageName));
            }

            #endregion

            query = query.OrderByDescending(r => r.CreateDate);

            #region paging

            await filter.SetPaging(query);

            #endregion

            return filter;
        }

        public async Task<List<Image>> GetImagesForIndex()
        {
            return await _galleryReporitory.GetImagesForIndex();
        }

        public async Task<List<Image>> GetImagesByGroupId(long groupId)
        {
            return await _galleryReporitory.GetImagesByGroupId(groupId);
        }

        public async Task<CreateImageResult> CreateImage(CreateImageViewModel create)
        {
            var gallery = await _galleryReporitory.GetGalleryById(create.GalleryId);

            if (gallery == null)
            {
                return CreateImageResult.Failure;
            }

            if(create.AvatarImage != null && create.AvatarImage.Any())
            {
                foreach (var img in create.AvatarImage)
                {
                    var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(img.FileName);
                    img.AddImageToServerWithOutThumb(imageName, SiteTools.GalleryImagesMethod(gallery.GallryName), 100, 100);

                    var image = new Image()
                    {
                        ImageName = imageName,
                        GalleryId = create.GalleryId,
                        IsSuccess = true,
                    };

                    await _galleryReporitory.AddImage(image);
                }

                await _galleryReporitory.SaveChanges();

                return CreateImageResult.Success;
            }

            return CreateImageResult.Failure;
        }

        public async Task<EditImageViewModel> GetImageForEdit(long imageId)
        {
            var image = await _galleryReporitory.GetImageyById(imageId);

            if (image == null)
            {
                return null;
            }

            return new EditImageViewModel()
            {
                ImageId = image.Id,
                ImageName = image.ImageName,
                GalleryId = image.GalleryId,
                GalleryName = image.Gallery.GallryName
            };
        }

        public async Task<EditImageResult> EditImage(EditImageViewModel edit)
        {
            var image = await _galleryReporitory.GetImageyById(edit.ImageId);

            var newGalleryName = await _galleryReporitory.GetGalleryById(edit.GalleryId);

            if (image == null)
            {
                return EditImageResult.HasNotItem;
            }

            if (edit.AvatarImage != null)
            {
                image.ImageName.RemoveImage(SiteTools.GalleryImagesMethod(edit.GalleryName));

                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(edit.AvatarImage.FileName);
                edit.AvatarImage.AddImageToServerWithOutThumb(imageName, SiteTools.GalleryImagesMethod(edit.GalleryName), 100, 100);

                image.ImageName = imageName;

                _galleryReporitory.UpdateImage(image);
                await _galleryReporitory.SaveChanges();

                return EditImageResult.Success;
            }

            if (newGalleryName!.GallryName != edit.GalleryName)
            {
                string LastSaveDir = "wwwroot/Img/GalleryImages/" + edit.GalleryName;
                string LastSavePath = Path.Combine(Directory.GetCurrentDirectory(), LastSaveDir, image.ImageName);

                string newSaveDir = "wwwroot/Img/GalleryImages/" + newGalleryName;
                if (!Directory.Exists(newSaveDir))
                {
                    Directory.CreateDirectory(newSaveDir);
                }

                string newSavePath = Path.Combine(Directory.GetCurrentDirectory(), newSaveDir, image.ImageName);
                File.Move(LastSavePath, newSavePath, true);

                image!.GalleryId = edit.GalleryId;

                _galleryReporitory.UpdateImage(image);
                await _galleryReporitory.SaveChanges();

                return EditImageResult.Success;
            }

            image!.GalleryId = edit.GalleryId;

            _galleryReporitory.UpdateImage(image);
            await _galleryReporitory.SaveChanges();

            return EditImageResult.Success;
        }

        public async Task<DetailsImageViewModel> DetailsImage(long imageId)
        {
            var image = await _galleryReporitory.GetImageyById(imageId);

            if (image == null)
            {
                return null;
            }

            return new DetailsImageViewModel()
            {
                ImageName = image.ImageName,
                IsSuccess = image.IsSuccess,
                GalleryName = image.Gallery.GallryName
            };
        }

        public async Task<bool> DeleteImage(long imageId)
        {
            var image = await _galleryReporitory.GetImageyById(imageId);

            if (image == null)
            {
                return false;
            }

            image.IsDelete = true;

            _galleryReporitory.UpdateImage(image);
            await _galleryReporitory.SaveChanges();

            return true;
        }

        #endregion

        #endregion
    }
}
