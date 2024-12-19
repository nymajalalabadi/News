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

        public async Task<IQueryable<Comment>> GetCommentsIsSuccesQuery()
        {
            return  _context.Comments
                .Include(c => c.Report)
                .Where(c => !c.IsDelete && c.IsSuccess).AsQueryable();
        }

        public async Task<IQueryable<Comment>> GetCommentsNotSuccesQuery()
        {
            return _context.Comments
                .Include(c => c.Report)
                .Where(c => !c.IsDelete && !c.IsSuccess).AsQueryable();
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

        #region contact us

        public async Task<ContactUs?> GetContactUsForIndex()
        {
            return await _context.ContactUs.Where(r => !r.IsDelete).FirstOrDefaultAsync();  
        }

        public async Task<ContactUs?> GetContactUsForEdit()
        {
            return await _context.ContactUs.Where(r => !r.IsDelete).FirstOrDefaultAsync();
        }

        public async Task AddContactUs(ContactUs contactUs)
        {
            await  _context.ContactUs.AddAsync(contactUs);   
        }

        public void UpdateContactUs(ContactUs contactUs)
        {
            _context.ContactUs.Update(contactUs);
        }

        #endregion

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync(); 
        }

        #endregion
    }
}
