﻿using News.Domain.Entities.Account;
using News.Domain.Entities.Hashtags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.InterFaces
{
    public interface IAccountRepository
    {
        #region Methods

        #region Comment

        Task<IQueryable<Comment>> GetCommentsQuery();

        Task<List<Comment>> GetCommentsForIndex();

        Task<Comment?> GetCommentById(long id);

        Task AddComment(Comment comment);

        void UpdateComment(Comment comment);

        #endregion

        Task SaveChanges();

        #endregion
    }
}