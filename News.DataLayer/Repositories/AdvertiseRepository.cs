﻿using News.DataLayer.Context;
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

        #endregion
    }
}
