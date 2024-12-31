using News.Domain.Entities.Account;
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

        #region user

        Task<IQueryable<Users>> GetUsersQuery();

        Task<Users?> GetUserById(long id);

        Task AddUser(Users users);

        void UpdateUser(Users users);

        #endregion

        #region Comment

        Task<IQueryable<Comment>> GetCommentsIsSuccesQuery();

        Task<IQueryable<Comment>> GetCommentsNotSuccesQuery();

        Task<List<Comment>> AllReportCommentByreportId(long reportId);

        Task<List<Comment>> GetCommentsForIndex();

        Task<Comment?> GetCommentById(long id);

        Task AddComment(Comment comment);

        void UpdateComment(Comment comment);

        #endregion

        #region contact us

        Task<IQueryable<ContactUs>> GetContactUssQuery();

        Task<ContactUs?> GetContactUsById(long id);

        Task AddContactUs(ContactUs contactUs);

        void UpdateContactUs(ContactUs contactUs);

        #endregion

        Task SaveChanges();

        #endregion
    }
}
