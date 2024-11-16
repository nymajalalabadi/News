﻿using News.Domain.Entities.Hashtags;
using News.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.InterFaces
{
    public interface IHashtagReporistory
    {
        #region Methods

        Task<IQueryable<Hashtag>> GetHashtagsQuery();

        Task<Hashtag?> GetHashtagById(long id);   

        Task AddHashtag(Hashtag hashtag);

        void UpdateHashtag(Hashtag hashtag);

        Task SaveChanges();

        #endregion
    }
}
