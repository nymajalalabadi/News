using News.Application.Services.Interfaces;
using News.Domain.Entities.Account;
using News.Domain.InterFaces;
using News.Domain.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Services.Implementations
{
    public class AccountService : IAccountService
    {
        #region Constructor

        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        #endregion

        #region Methods

        #region Comment

        public async Task<FilterCommentViewModel> GetFilterComments(FilterCommentViewModel filter)
        {
            var query = await _accountRepository.GetCommentsQuery();

            #region Filter

            if (!string.IsNullOrWhiteSpace(filter.Email))
            {
                query = query.Where(p => p.Email.Contains(filter.Email));
            }

            #endregion

            query = query.OrderByDescending(p => p.CreateDate);

            #region paging

            await filter.SetPaging(query);

            #endregion

            return filter;
        }

        public async Task<CreateCommentResult> CreateComment(CreateCommentViewModel create)
        {
            if (create.Email == null || create.Name == null)
            {
                return CreateCommentResult.Error;
            }

            var newComment = new Comment()
            {
                Email = create.Email,
                Name = create.Name,
                CommentText = create.CommentText,
                IsSuccess = false
            };

            await _accountRepository.AddComment(newComment);
            await _accountRepository.SaveChanges();

            return CreateCommentResult.Success;
        }

        public async Task<DetailsCommentViewModel> DetailsComment(long commentId)
        {
            var comment = await _accountRepository.GetCommentById(commentId);

            if (comment == null)
            {
                return null;
            }

            return new DetailsCommentViewModel()
            {
                Email = comment.Email,
                Name = comment.Name,
                CommentText = comment.CommentText,
                CreateDate = comment.CreateDate.ToShortDateString(),
            };
        }

        #endregion

        #endregion
    }
}
