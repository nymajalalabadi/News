﻿using News.Domain.Entities.Galleries;
using News.Domain.Entities.Hashtags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.InterFaces
{
    public interface IGalleryReporitory
    {
        #region Gallery

        #region Methods

        Task<IQueryable<Gallery>> GetGalleriesQuery();

        Task<List<Gallery>> GetGalleriesForIndex();

        Task<Gallery?> GetGalleryById(long id);

        Task<bool> IsExistGallryName(string gallryName);

        Task AddGallery(Gallery gallery);

        void UpdateGallery(Gallery gallery);

        Task SaveChanges();

        #endregion

        #endregion
    }
}