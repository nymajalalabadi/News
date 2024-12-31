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

        #region user

        public async Task<IQueryable<Users>> GetUsersQuery()
        {
            return _context.Users
                .Where(u => u.IsDelete == false)
                .AsQueryable();
        }

        public async Task<Users?> GetUserById(long id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddUser(Users users)
        {
            await _context.Users.AddAsync(users);
        }

        public void UpdateUser(Users users)
        {
           _context.Users.Update(users);
        }

        #endregion

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

        public async Task<IQueryable<ContactUs>> GetContactUssQuery()
        {
            return _context.ContactUs.Where(r => !r.IsDelete).AsQueryable();  
        }

        public async Task<ContactUs?> GetContactUsById(long id)
        {
            return await _context.ContactUs.Where(r => !r.IsDelete).FirstOrDefaultAsync(c => c.Id == id);
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
