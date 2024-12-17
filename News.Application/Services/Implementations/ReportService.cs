using Microsoft.AspNetCore.Mvc.Rendering;
using News.Application.Generators;
using News.Application.Services.Interfaces;
using News.Application.Statics;
using News.DataLayer.Context;
using News.Domain.Entities.Reports;
using News.Domain.InterFaces;
using News.Domain.ViewModels.ReportGroups;
using News.Domain.ViewModels.Reports;
using SixLabors.ImageSharp;
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

        public async Task<FilterReportsMostViewsViewModel> GetFilterReportsForMostViews(FilterReportsMostViewsViewModel filter)
        {
            var query = await _reportReporistory.GetReportsQuery();

            #region Filter

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(r => r.Title.Contains(filter.Title));
            }

            #endregion

            query = query.OrderByDescending(r => r.Visit);

            #region paging

            await filter.SetPaging(query);

            #endregion

            return filter;
        }

        public async Task<FilterReportForShowViewModel> GetFilterReportForIndex(FilterReportForShowViewModel filter)
        {
            var query = await _reportReporistory.GetReportsQuery();

            #region Filter

            if (!string.IsNullOrEmpty(filter.UrlName))
            {
                query = query.Where(r => r.ReportGroup.UrlName.Contains(filter.UrlName));
            }

            #endregion

            query = query.OrderByDescending(r => r.CreateDate);

            #region paging

            await filter.SetPaging(query);

            #endregion

            return filter;
        }

        public async Task<FilterHotNewsReportForShowViewModel> GetFilterHotNewsReportForIndex(FilterHotNewsReportForShowViewModel filter)
        {
            var query = await _reportReporistory.GetHotNewsReportsQuery();

            query = query.OrderByDescending(r => r.HotNewsDate);

            #region paging

            await filter.SetPaging(query);

            #endregion

            return filter;
        }

        public async Task<Report?> GetSpecialReportForIndex(string groupUrl)
        {
            return await _reportReporistory.GetSpecialReportForIndex(groupUrl);
        }

        public async Task<Report?> GetHotNewsReportForIndex()
        {
            return await _reportReporistory.GetHotNewsReportForIndex();
        }

        public async Task<List<Report>> GetLastReportsForIndex()
        {
            return await _reportReporistory.GetLastReportsForIndex();
        }

        public async Task<List<Report>> GetReportsForFooter()
        {
            return await _reportReporistory.GetReportsForFooter();
        }

        public async Task<List<Report>> GetReportsForIndex(string groupUrl)
        {
            return await _reportReporistory.GetReportsForIndex(groupUrl);
        }

        public async Task<List<Report>> GetTopReportsForIndex(string groupUrl)
        {
            return await _reportReporistory.GetTopReportsForIndex(groupUrl);
        }

        public async Task<List<Report>> GetSpecialReportsForIndex(string groupUrl)
        {
            return await _reportReporistory.GetSpecialReportsForIndex(groupUrl);
        }

        public async Task<List<Report>> GetHotNewsReportsForIndex()
        {
            return await _reportReporistory.GetHotNewsReportsForIndex();
        }

        public async Task<List<Report>> GetRelatedReportsForIndex(string groupUrl, long reportId)
        {
            return await _reportReporistory.GetRelatedReportsForIndex(groupUrl, reportId);
        }

        public async Task<ReportsListForShowIndex> GetReportsListForShowIndex(string groupUrlName)
        {
            var group = await _reportReporistory.GetReportGroupByUrlName(groupUrlName);

            var reports = await _reportReporistory.GetReportsForIndex(groupUrlName);    

            if (group == null || reports == null)
            {
                return null;
            }

            return new ReportsListForShowIndex()
            {
                ReportGroup = group,
                Reports = reports
            };
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
                    IsSuccess = true,
                    ReportGroupId = report.groupId,
                    Image = imageName
                };

                await _reportReporistory.AddReport(newReport);
                await _reportReporistory.SaveChanges();

                return CreateReportResult.Success;
            }

            return CreateReportResult.NoImage;
        }

        public async Task<EditReportViewModel> GetReportForEdit(long reportId)
        {
            var report = await _reportReporistory.GetReportById(reportId);

            if (report == null)
            {
                return null;
            }

            return new EditReportViewModel()
            {
                ReportId = report.Id,
                Title = report.Title,
                Description = report.Description,
                Tags = report.Tags,
                FullText = report.FullText,
                Author = report.Author,
                Image = report.Image,
                ImageAlt = report.ImageAlt,
                ImageTitle = report.ImageTitle,
                Source = report.Source,
                GroupId = report.ReportGroupId
            };
        }

        public async Task<EditReportResult> EditReport(EditReportViewModel report)
        {
            var currentReport = await _reportReporistory.GetReportById(report.ReportId);

            if (currentReport == null)
            {
                return EditReportResult.HasNotItem;
            }

            if (report.Title == null)
            {
                return EditReportResult.Error;
            }

            if (report.AvatarImage != null)
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(report.AvatarImage.FileName);
                report.AvatarImage.AddImageToServer(imageName, SiteTools.ReportImagesName, 100, 100, SiteTools.ReportImagesName, currentReport.Image);

                currentReport.Title = report.Title;
                currentReport.Description = report.Description;
                currentReport.FullText = report.FullText;
                currentReport.Source = report.Source;
                currentReport.Author = report.Author;
                currentReport.Tags = report.Tags;
                currentReport.LastUpdateDate = DateTime.Now;
                currentReport.ImageAlt = report.ImageAlt;
                currentReport.ImageTitle= report.ImageTitle;
                currentReport.Image = imageName;

                _reportReporistory.UpdateReport(currentReport);
                await _reportReporistory.SaveChanges();

                return EditReportResult.Success;
            }

            currentReport.Title = report.Title;
            currentReport.Description = report.Description;
            currentReport.FullText = report.FullText;
            currentReport.Source = report.Source;
            currentReport.Author = report.Author;
            currentReport.Tags = report.Tags;
            currentReport.LastUpdateDate = DateTime.Now;
            currentReport.ImageAlt = report.ImageAlt;
            currentReport.ImageTitle = report.ImageTitle;

            _reportReporistory.UpdateReport(currentReport);
            await _reportReporistory.SaveChanges();

            return EditReportResult.Success;
        }

        public async Task<DetailsReportViewModel> DetailsReport(long reportId)
        {
            var report = await _reportReporistory.GetReportById(reportId);

            if (report == null)
            {
                return null;
            }

            return new DetailsReportViewModel()
            {
                Title = report!.Title,
                Description = report.Description,
                Author = report.Author,
                FullText = report.FullText,
                ImageTitle = report.ImageTitle,
                Image = report.Image,
                Tags = report.Tags,
                ImageAlt = report.ImageAlt,
                Source = report.Source,
                GroupReport = report.ReportGroup.GroupName,
            };
        }

        public async Task<bool> DeleteReport(long reportId)
        {
            var report = await _reportReporistory.GetReportById(reportId);

            if (report == null)
            {
                return false;
            }

            report.IsDelete = true;
            report.LastUpdateDate = DateTime.Now;

            _reportReporistory.UpdateReport(report);
            await _reportReporistory.SaveChanges();

            return true;
        }

        public async Task<bool> HotReport(long reportId)
        {
            var report = await _reportReporistory.GetReportById(reportId);

            if (report == null)
            {
                return false;
            }

            report.IsHotNews = true;
            report.HotNewsDate = DateTime.Now;
            report.LastUpdateDate = DateTime.Now;

            _reportReporistory.UpdateReport(report);
            await _reportReporistory.SaveChanges();

            return true;
        }

        public async Task<GetReportForShow> GetReportForShowById(long reportId)
        {
            var report = await _reportReporistory.GetReportById(reportId);

            if (report == null)
            {
                return null;
            }

            return new GetReportForShow()
            {
                ReportId = report.Id,
                Title = report.Title,
                Description = report.Description,
                Author = report.Author,
                FullText = report.FullText,
                ImageTitle = report.ImageTitle,
                Image = report.Image,
                Tags = report.Tags,
                ImageAlt = report.ImageAlt,
                Source = report.Source,
                CreateDate = report.CreateDate,
                ReportGroup = report.ReportGroup
            };
        }

        #endregion

        #region Reports Group

        public async Task<List<SelectListItem>> SelectedReportGroupId()
        {
            return await _reportReporistory.SelectedReportGroupId();
        }

        public async Task<ReportGroup?> GetReportGroupByUrlName(string urlName)
        {
            return await _reportReporistory.GetReportGroupByUrlName(urlName);
        }

        public async Task<FilterReportGroupsViewModel> GetFilterReportGroups(FilterReportGroupsViewModel filter)
        {
            var query = await _reportReporistory.GetReportGroupsQuery();

            #region Filter

            if (!string.IsNullOrEmpty(filter.GroupName))
            {
                query = query.Where(r => r.GroupName.Contains(filter.GroupName));
            }

            #endregion

            query = query.OrderByDescending(r => r.CreateDate);

            #region paging

            await filter.SetPaging(query);

            #endregion

            return filter;
        }

        public async Task<List<ReportGroup>> GetReportGroupsForIndex()
        {
            return await _reportReporistory.GetReportGroupsForIndex();
        }

        public async Task<List<ReportGroup>> GetAllReportGroupsForIndex()
        {
            return await _reportReporistory.GetAllReportGroupsForIndex();
        }

        public async Task<CreateReportGroupResult> CreateReportGroup(CreateReportGroupViewModel reportGroup)
        {
            if (string.IsNullOrEmpty(reportGroup.GroupName)) 
            {
                return CreateReportGroupResult.Failure; 
            }

            if (string.IsNullOrEmpty(reportGroup.UrlName))
            {
                return CreateReportGroupResult.Failure;
            }

            if (await _reportReporistory.IsExistReportGroupByUrlName(reportGroup.UrlName))
            {
                return CreateReportGroupResult.IsExistUrlName;
            }

            if (reportGroup.AvatarImage != null)
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(reportGroup.AvatarImage.FileName);
                reportGroup.AvatarImage.AddImageToServer(imageName, SiteTools.ReportGroupImagesName, 100, 100, SiteTools.ReportGroupImagesName);

                var group = new ReportGroup()
                {
                    GroupName = reportGroup.GroupName,
                    GroupImage = imageName,
                    UrlName = reportGroup.UrlName
                };

                await _reportReporistory.AddReportGroup(group);
                await _reportReporistory.SaveChanges();

                return CreateReportGroupResult.Success;
            }

            var groupWithOutImage = new ReportGroup()
            {
                GroupName = reportGroup.GroupName,
                UrlName = reportGroup.UrlName
            };

            await _reportReporistory.AddReportGroup(groupWithOutImage);
            await _reportReporistory.SaveChanges();

            return CreateReportGroupResult.Success;
        }

        public async Task<EditReportGroupViewModel> GetReportGroupForEdit(long reportGroupId)
        {
            var reportGroup = await _reportReporistory.GetReportGroupById(reportGroupId);

            if (reportGroup == null)
            {
                return null;
            }

            return new EditReportGroupViewModel()
            {
                Id = reportGroup.Id,
                GroupName = reportGroup.GroupName,
                GroupImage = reportGroup.GroupImage,
                UrlName= reportGroup.UrlName
            };
        }

        public async Task<EditReportGroupResult> EditReportGroup(EditReportGroupViewModel reportGroup)
        {
            var currentReportGroup = await _reportReporistory.GetReportGroupById(reportGroup.Id);

            if (currentReportGroup == null)
            {
                return EditReportGroupResult.HasNotItem;
            }

            if (currentReportGroup.GroupName == null)
            {
                return EditReportGroupResult.Failure;
            }

            if (reportGroup.AvatarImage != null)
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(reportGroup.AvatarImage.FileName);
                reportGroup.AvatarImage.AddImageToServer(imageName, SiteTools.ReportGroupImagesName, 100, 100, SiteTools.ReportGroupImagesName, currentReportGroup.GroupImage!);

                currentReportGroup.GroupName = reportGroup.GroupName;
                currentReportGroup.LastUpdateDate = DateTime.Now;
                currentReportGroup.GroupImage = imageName;
                currentReportGroup.UrlName = reportGroup.UrlName;

                _reportReporistory.UpdateReportGroup(currentReportGroup);
                await _reportReporistory.SaveChanges();

                return EditReportGroupResult.Success;
            }

            currentReportGroup.GroupName = reportGroup.GroupName;
            currentReportGroup.LastUpdateDate = DateTime.Now;
            currentReportGroup.UrlName = reportGroup.UrlName;

            _reportReporistory.UpdateReportGroup(currentReportGroup);
            await _reportReporistory.SaveChanges();

            return EditReportGroupResult.Success;
        }

        public async Task<DetailsReportGroupViewModel> DetailsReportGroup(long reportGroupId)
        {
            var reportGroup = await _reportReporistory.GetReportGroupById(reportGroupId);

            if (reportGroup == null)
            {
                return null;
            }

            return new DetailsReportGroupViewModel()
            {
                GroupName = reportGroup.GroupName,
                GroupImage = reportGroup.GroupImage,
                UrlName = reportGroup.UrlName,
            };
        }

        public async Task<bool> DeleteReportGroup(long reportGroupId)
        {
            var reportGroup = await _reportReporistory.GetReportGroupById(reportGroupId);

            if (reportGroup == null)
            {
                return false;
            }

            reportGroup.IsDelete = true;

            _reportReporistory.UpdateReportGroup(reportGroup);
            await _reportReporistory.SaveChanges();

            return true;
        }

        #endregion

        #endregion
    }
}
