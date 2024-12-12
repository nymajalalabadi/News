using News.Application.Generators;
using News.Application.Services.Interfaces;
using News.Application.Statics;
using News.DataLayer.Repositories;
using News.Domain.Entities.Advertises;
using News.Domain.Entities.Reports;
using News.Domain.InterFaces;
using News.Domain.ViewModels.Advertises;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Services.Implementations
{
    public class AdvertiseService : IAdvertiseService
    {
        #region Constructor

        private readonly IAdvertiseRepository _advertiseRepository;

        public AdvertiseService(IAdvertiseRepository advertiseRepository)
        {
            _advertiseRepository = advertiseRepository;
        }

        #endregion

        #region Methods

        public async Task<FilterAdvertisesViewModel> GetFilterAdvertisesGroups(FilterAdvertisesViewModel filter)
        {
            var query = await _advertiseRepository.GetAdvertisesQuery();

            #region Filter

            if (!string.IsNullOrEmpty(filter.AdsName))
            {
                query = query.Where(r => r.AdsName!.Contains(filter.AdsName));
            }

            #endregion

            query = query.OrderByDescending(r => r.CreateDate);

            #region paging

            await filter.SetPaging(query);

            #endregion

            return filter;
        }

        public async Task<List<Advertise>> GetAdvertisesForIndex()
        {
            return await _advertiseRepository.GetAdvertisesForIndex();  
        }

        public async Task<CreateAdvertiseResult> CreateAdvertiseGroup(CreateAdvertiseViewModel create)
        {
            if (create.AvatarImage != null)
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(create.AvatarImage.FileName);
                create.AvatarImage.AddImageToServer(imageName, SiteTools.AdsImagesName, 100, 100, SiteTools.AdsImagesName);

                var advertise = new Advertise
                {
                    AdsName = create.AdsName,
                    Image = imageName,
                    Email = create.Email,
                    ExpireDate = create.ExpireDate,
                    Subject = create.Subject,
                    PhoneNumber = create.PhoneNumber,
                    price = create.price,
                };

                await _advertiseRepository.AddAdvertise(advertise);
                await _advertiseRepository.SaveChanges();

                return CreateAdvertiseResult.created;
            }


            var ads = new Advertise
            {
                AdsName = create.AdsName,
                Email = create.Email,
                ExpireDate = create.ExpireDate,
                Subject = create.Subject,
                PhoneNumber = create.PhoneNumber,
                price = create.price,
            };

            await _advertiseRepository.AddAdvertise(ads);
            await _advertiseRepository.SaveChanges();

            return CreateAdvertiseResult.created;
        }

        public async Task<EditAdvertiseViewModel> GetAdvertiseForEdit(long advertiseId)
        {
            var advertise = await _advertiseRepository.GetAdvertiseById(advertiseId);

            if (advertise == null)
            {
                return null;
            }

            return new EditAdvertiseViewModel()
            {
                AdvertiseId = advertise.Id,
                AdsName = advertise.AdsName,
                Email = advertise.Email,
                ExpireDate = advertise.ExpireDate,
                Subject = advertise.Subject,
                PhoneNumber = advertise.PhoneNumber,
                price = advertise.price,
                Image = advertise.Image,
            };
        }

        public async Task<EditAdvertiseResult> EditAdvertise(EditAdvertiseViewModel editAdvertise) 
        {
            var advertise = await _advertiseRepository.GetAdvertiseById(editAdvertise.AdvertiseId);

            if (advertise == null)
            {
                return EditAdvertiseResult.NotFound;
            }

            if (editAdvertise.AvatarImage != null)
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(editAdvertise.AvatarImage.FileName);
                editAdvertise.AvatarImage.AddImageToServer(imageName, SiteTools.AdsImagesName, 100, 100, SiteTools.AdsImagesName, advertise.Image!);

                advertise.Image = imageName;
                advertise.LastUpdateDate = DateTime.Now;
                advertise.AdsName = editAdvertise.AdsName;
                advertise.Email = editAdvertise.Email;
                advertise.ExpireDate = editAdvertise.ExpireDate;
                advertise.Subject = editAdvertise.Subject;
                advertise.PhoneNumber = editAdvertise.PhoneNumber;
                advertise.price = editAdvertise.price;

                _advertiseRepository.UpdateAdvertise(advertise);
                await _advertiseRepository.SaveChanges();

                return EditAdvertiseResult.success;
            }

            advertise.LastUpdateDate = DateTime.Now;
            advertise.AdsName = editAdvertise.AdsName;
            advertise.Email = editAdvertise.Email;
            advertise.ExpireDate = editAdvertise.ExpireDate;
            advertise.Subject = editAdvertise.Subject;
            advertise.PhoneNumber = editAdvertise.PhoneNumber;
            advertise.price = editAdvertise.price;

            _advertiseRepository.UpdateAdvertise(advertise);
            await _advertiseRepository.SaveChanges();

            return EditAdvertiseResult.success;
        }

        public async Task<DetailsAdvertiseViewModel> DetailsAdvertise(long advertiseId)
        {
            var advertise = await _advertiseRepository.GetAdvertiseById(advertiseId);

            if (advertise == null)
            {
                return null;
            }

            return new DetailsAdvertiseViewModel()
            {
                AdvertiseId = advertise.Id,
                AdsName = advertise.AdsName,
                Email = advertise.Email,
                ExpireDate = advertise.ExpireDate,
                Subject = advertise.Subject,
                PhoneNumber = advertise.PhoneNumber,
                price = advertise.price,
                Image = advertise.Image,
            };
        }

        public async Task<bool> DeleteAdvertise(long advertiseId)
        {
            var advertise = await _advertiseRepository.GetAdvertiseById(advertiseId);

            if (advertise == null)
            {
                return false;
            }

            advertise.IsDelete = true;

            _advertiseRepository.UpdateAdvertise(advertise);
            await _advertiseRepository.SaveChanges();

            return true;
        }

        #endregion
    }
}
