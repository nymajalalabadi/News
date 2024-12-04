using Microsoft.EntityFrameworkCore;
using News.DataLayer.Context;
using News.Domain.Entities.Account;
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

        public async Task<IQueryable<Comment>> GetCommentsQuery()
        {
            return  _context.Comments
                .Include(c => c.Report)
                .Where(c => !c.IsDelete).AsQueryable();
        }

        public async Task<List<Comment>> AllReportCommentByreportId(long reportId)
        {
            return await _context.Comments
                .Include(c => c.Report)
                .Where(c => !c.IsDelete && c.IsSuccess && c.ReportId == reportId).ToListAsync();
        }

        public async Task<List<Comment>> GetCommentsForIndex()
        {
            return await _context.Comments
                .Include(c => c.Report)
                .Where(c => !c.IsDelete).ToListAsync();
        }

        public async Task<Comment?> GetCommentById(long id)
        {
            return await _context.Comments.Include(c => c.Report).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddComment(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        }

        public void UpdateComment(Comment comment)
        {
            _context.Comments.Update(comment);
        }

        #endregion

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync(); 
        }

        #endregion
    }
}
