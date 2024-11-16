using News.Application.Services.Interfaces;
using News.Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Services.Implementations
{
    public class HashtagService : IHashtagService
    {
        #region Constructor

        private readonly IHashtagReporistory _hashtagReporistory;

        public HashtagService(IHashtagReporistory hashtagReporistory)
        {
            _hashtagReporistory = hashtagReporistory;
        }

        #endregion

        #region Methods



        #endregion
    }
}
