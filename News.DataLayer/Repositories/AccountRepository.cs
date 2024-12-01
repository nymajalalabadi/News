using News.DataLayer.Context;
using News.Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataLayer.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        #region Constructor

        private readonly NewsDbContext _context;

        public AccountRepository(NewsDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        #region Comment

        #endregion

        #endregion
    }
}
