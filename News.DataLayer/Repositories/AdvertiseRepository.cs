using Microsoft.EntityFrameworkCore;
using News.DataLayer.Context;
using News.Domain.Entities.Advertises;
using News.Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataLayer.Repositories
{
    public class AdvertiseRepository : IAdvertiseRepository
    {
        #region Constructor

        private readonly NewsDbContext _context;

        public AdvertiseRepository(NewsDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<IQueryable<Advertise>> GetAdvertisesQuery()
        {
            return _context.Advertises.Where(a => !a.IsDelete).AsQueryable();
        }

        public async Task<List<Advertise>> GetAdvertisesForIndex()
        {
            return await _context.Advertises.Take(4).Where(a => !a.IsDelete).ToListAsync();
        }

        public async Task<Advertise?> GetAdvertiseById(long id)
        {
            return await _context.Advertises.FirstOrDefaultAsync(a => a.Id.Equals(id));
        }

        public async Task AddAdvertise(Advertise advertise)
        {
            await _context.Advertises.AddAsync(advertise);
        }

        public void UpdateAdvertise(Advertise advertise)
        {
             _context.Advertises.Update(advertise);
        }

        public async Task SaveChanges()
        {
            await  _context.SaveChangesAsync(); 
        }

        #endregion
    }
}
