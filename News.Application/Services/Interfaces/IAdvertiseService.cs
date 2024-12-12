using News.Domain.Entities.Advertises;
using News.Domain.Entities.Hashtags;
using News.Domain.ViewModels.Advertises;
using News.Domain.ViewModels.Hashtags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Services.Interfaces
{
    public interface IAdvertiseService
    {
        #region Methods

        Task<FilterAdvertisesViewModel> GetFilterAdvertisesGroups(FilterAdvertisesViewModel filter);

        Task<List<Advertise>> GetAdvertisesForIndex();

        Task<CreateAdvertiseResult> CreateAdvertiseGroup(CreateAdvertiseViewModel create);

        Task<EditAdvertiseViewModel> GetAdvertiseForEdit(long advertiseId);

        Task<EditAdvertiseResult> EditAdvertise(EditAdvertiseViewModel editAdvertise);

        Task<DetailsAdvertiseViewModel> DetailsAdvertise(long advertiseId);

        Task<bool> DeleteAdvertise(long advertiseId);

        #endregion
    }
}
