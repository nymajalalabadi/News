﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Images
{
    public class CreateImageViewModel
    {
        public long GalleryId { get; set; }

        [Display(Name = "عکس اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public List<IFormFile> AvatarImage { get; set; }
    }
    public enum CreateImageResult
    {
        Success,
        Failure
    }
}
