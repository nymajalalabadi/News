﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Statics
{
    public class SiteTools
    {
        #region DefaultNames

        public static string DefaultImageName { get; set; } = "/Img/ProfileImages/DefaultUserImage/DefaultUserProfile.jpg";

        #endregion

        #region Image Report

        public static string ReportImagesName { get; set; } = "/Img/ReportImages/";

        #endregion

        #region Image Report Group

        public static string ReportGroupImagesName { get; set; } = "/Img/ReportGroupImages/";

        #endregion

        #region Gallery Images Name

        public static string GalleryImagesMethod(string imageName)
        {
            return $"/Img/GalleryImages/{imageName}/";
        }

        #endregion


        #region Ads

        public static string AdsImagesName { get; set; } = "/Img/AdsImages/";

        #endregion
    }
}
