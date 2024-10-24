﻿using Microsoft.AspNetCore.Mvc.Rendering;
using News.Application.Generators;
using News.Application.Services.Interfaces;
using News.Application.Statics;
using News.DataLayer.Context;
using News.Domain.Entities.Reports;
using News.Domain.InterFaces;
using News.Domain.ViewModels.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Services.Implementations
{
    public class ReportService : IReportService
    {
        #region Constructor

        private readonly IReportReporistory _reportReporistory;

        public ReportService(IReportReporistory reportReporistory)
        {
            _reportReporistory = reportReporistory;
        }

        #endregion

        #region Methods

        #region Reports

        public async Task<FilterReportsViewModel> GetFilterReports(FilterReportsViewModel filter)
        {
            var query = await _reportReporistory.GetReportsQuery();

            #region Filter

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(r => r.Title.Contains(filter.Title));
            }

            #endregion

            #region State

            switch (filter.FilterReportsState)
            {
                case FilterReportsState.All:
                    break;
                case FilterReportsState.Normal:
                    query = query.Where(r => !r.IsHotNews);
                    break;
                case FilterReportsState.IsHotNews:
                    query = query.Where(r => r.IsHotNews);
                    break;
                case FilterReportsState.IsSuccess:
                    query = query.Where(r => r.IsSuccess);
                    break;
                case FilterReportsState.IsNotSuccess:
                    query = query.Where(r => !r.IsSuccess);
                    break;
            }

            #endregion

            query = query.OrderByDescending(r => r.CreateDate);

            #region paging

            await filter.SetPaging(query);

            #endregion

            return filter;  
        }

        public async Task<CreateReportResult> CreateReport(CreateReportViewModel report)
        {
            if (report.Title == null)
            {
                return CreateReportResult.Error;
            }

            if (report.AvatarImage != null)
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(report.AvatarImage.FileName);
                report.AvatarImage.AddImageToServer(imageName, SiteTools.ReportImagesName, 100, 100, SiteTools.ReportImagesName);

                var newReport = new Report()
                {
                    Title = report.Title,
                    Description = report.Description,
                    FullText = report.FullText,
                    Author = report.Author,
                    ImageAlt = report.ImageAlt,
                    ImageTitle = report.ImageTitle,
                    Source = report.Source,
                    Tags = report.Tags,
                    ReportGroupId = report.groupId,
                    Image = imageName
                };

                await _reportReporistory.AddReport(newReport);
                await _reportReporistory.SaveChanges();

                return CreateReportResult.Success;
            }

            return CreateReportResult.NoImage;
        }

        #endregion

        #region Reports Group

        public async Task<List<SelectListItem>> SelectedReportGroupId()
        {
            return await _reportReporistory.SelectedReportGroupId();
        }

        #endregion

        #endregion
    }
}
