using News.Application.Services.Interfaces;
using News.Domain.InterFaces;
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



        #endregion
    }
}
