﻿using News.Application.Services.Interfaces;
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

        private readonly IReportReporistory _reportReporistory;

        public AccountService(IAccountRepository accountRepository, IReportReporistory reportReporistory)
        {
            _accountRepository = accountRepository;
            _reportReporistory = reportReporistory;
        }

        #endregion

        #region Methods

        #region Comment

        public async Task<FilterCommentViewModel> GetFilterCommentNotSuucess(FilterCommentViewModel filter)
        {
            var query = await _accountRepository.GetCommentsNotSuccesQuery();

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

        public async Task<FilterCommentViewModel> GetFilterCommentIsSuucess(FilterCommentViewModel filter)
        {
            var query = await _accountRepository.GetCommentsIsSuccesQuery();

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

        public async Task<List<Comment>> GetCommentsForIndex()
        {
            return await _accountRepository.GetCommentsForIndex();
        }

        public async Task<List<Comment>> AllReportCommentByreportId(long reportId)
        {
            return await _accountRepository.AllReportCommentByreportId(reportId);
        }

        public async Task<CreateCommentResult> CreateComment(CreateCommentViewModel create)
        {
            if (create.Email == null || create.Name == null)
            {
                return CreateCommentResult.Error;
            }

            var report = await _reportReporistory.GetReportById(create.ReportId);

            if (report == null)
            {
                return CreateCommentResult.CheckReport;
            }

            var newComment = new Comment()
            {
                ReportId = report.Id,
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
                IsSuccess = comment.IsSuccess,
                TitleReport = comment.Report.Title
            };
        }

        public async Task<bool> DeleteComment(long commentId)
        {
            var comment = await _accountRepository.GetCommentById(commentId);

            if (comment == null)
            {
                return false;
            }

            comment.IsDelete = true;

            _accountRepository.UpdateComment(comment);
            await _accountRepository.SaveChanges();

            return true;
        }

        public async Task<bool> IsSuccessComment(long commentId)
        {
            var comment = await _accountRepository.GetCommentById(commentId);

            if (comment == null)
            {
                return false;
            }

            comment.IsSuccess = true;

            _accountRepository.UpdateComment(comment);
            await _accountRepository.SaveChanges();

            return true;
        }

        #endregion

        #region Contact Us

        public async Task<FilterContactUsViewModel> GetContactUsForShow(FilterContactUsViewModel filter)
        {
            var query = await _accountRepository.GetContactUssQuery();

            #region Filter

            if (!string.IsNullOrWhiteSpace(filter.Email))
            {
                query = query.Where(p => p.Email!.Contains(filter.Email));
            }

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name!.Contains(filter.Name));
            }

            #endregion

            query = query.OrderByDescending(p => p.CreateDate);

            #region paging

            await filter.SetPaging(query);

            #endregion

            return filter;
        }

        public async Task<CreateContactUsReslut> CreateContactUs(CreateContactUsViewModel create)
        {
            if (create.Name == null || create.Message == null)
            {
                return CreateContactUsReslut.Error;
            }

            var newContactUs = new ContactUs()
            {
                Name = create.Name,
                Email = create.Email,
                PhoneNumber = create.PhoneNumber,
                Subject = create.Subject,
                Message = create.Message
            };

            await _accountRepository.AddContactUs(newContactUs);
            await _accountRepository.SaveChanges();

            return CreateContactUsReslut.Success;
        }

        public async Task<DetailsContactUsViewModel> DetailsContactUs(long contactUsId)
        {
            var contactUs = await _accountRepository.GetContactUsById(contactUsId);

            if (contactUs == null)
            {
                return null;
            }

            return new DetailsContactUsViewModel()
            {
                Email = contactUs.Email,
                PhoneNumber = contactUs.PhoneNumber,
                Name = contactUs.Name,
                Subject = contactUs.Subject,
                Message = contactUs.Message,
                Id = contactUs.Id
            };
        }

        public async Task<bool> DeleteContactUs(long contactUsId)
        {
            var contactUs = await _accountRepository.GetContactUsById(contactUsId);

            if (contactUs == null)
            {
                return false;
            }

            contactUs.IsDelete = true;

            _accountRepository.UpdateContactUs(contactUs);
            await _accountRepository.SaveChanges();

            return true;
        }

        #endregion

        #endregion
    }
}
