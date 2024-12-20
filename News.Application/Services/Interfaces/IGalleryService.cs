using Microsoft.AspNetCore.Mvc.Rendering;
using News.Domain.Entities.Galleries;
using News.Domain.Entities.Hashtags;
using News.Domain.ViewModels.Galleries;
using News.Domain.ViewModels.Hashtags;
using News.Domain.ViewModels.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Services.Interfaces
{
    public interface IGalleryService
    {
        #region gallery

        #region Methods

        Task<FilterGalleryViewModel> GetFilterGalleries(FilterGalleryViewModel filter);

        Task<List<Gallery>> GetGalleriesForIndex();

        Task<List<SelectListItem>> SelectedGalleryId();

        Task<CreateGalleryResult> CreateGallery(CreateGalleryViewModel create);

        Task<EditGalleryViewModel> GetGalleryForEdit(long galleryId);

        Task<EditGalleryResult> Editgallery(EditGalleryViewModel edit);

        Task<DetailsGalleryViewModel> DetailsGallery(long galleryId);

        Task<bool> DeleteGallery(long galleryId);

        #endregion

        #endregion

        #region image

        #region Methods

        Task<FilterImagesViewModel> GetFilterImages(FilterImagesViewModel filter);

        Task<List<Image>> GetImagesForIndex();

        Task<List<Image>> GetImagesByGroupId(long groupId);

        Task<CreateImageResult> CreateImage(CreateImageViewModel create);

        Task<EditImageViewModel> GetImageForEdit(long imageId);

        Task<EditImageResult> EditImage(EditImageViewModel edit);

        Task<DetailsImageViewModel> DetailsImage(long imageId);

        Task<bool> DeleteImage(long imageId);

        #endregion

        #endregion
    }
}
