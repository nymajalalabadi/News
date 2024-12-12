using News.Domain.Entities.Advertises;
using News.Domain.Entities.Hashtags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.InterFaces
{
    public interface IAdvertiseRepository
    {
        #region Methods

        Task<IQueryable<Advertise>> GetAdvertisesQuery();

        Task<List<Advertise>> GetAdvertisesForIndex();

        Task<Advertise?> GetAdvertiseById(long id);

        Task AddAdvertise(Advertise advertise);

        void UpdateAdvertise(Advertise advertise);

        Task SaveChanges();

        #endregion
    }
}
