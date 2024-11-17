using News.Application.Services.Interfaces;
using News.Domain.InterFaces;
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

        #region Methods



        #endregion
    }
}
