﻿using Microsoft.AspNetCore.Mvc.Rendering;
using News.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.InterFaces
{
    public interface IReportReporistory
    {
        #region Methods

        #region Reports

        Task<IQueryable<Report>> GetReportsQuery();

        Task<IQueryable<Report>> GetHotNewsReportsQuery();

        Task<Report?> GetSpecialReportForIndex(string groupUrl);

        Task<Report?> GetHotNewsReportForIndex();

        Task<List<Report>> GetLastReportsForIndex();

        Task<List<Report>> GetReportsForFooter();

        Task<List<Report>> GetReportsForIndex(string groupUrl);

        Task<List<Report>> GetTopReportsForIndex(string groupUrl);

        Task<List<Report>> GetSpecialReportsForIndex(string groupUrl);

        Task<List<Report>> GetRelatedReportsForIndex(string groupUrl, long reportId);

        Task<List<Report>> GetHotNewsReportsForIndex();

        Task<Report?> GetReportById(long id);

        Task AddReport(Report report);

        void UpdateReport(Report report);

        #endregion

        #region Group Reports

        Task<IQueryable<ReportGroup>> GetReportGroupsQuery();

        Task<List<ReportGroup>> GetReportGroupsForIndex();

        Task<List<ReportGroup>> GetAllReportGroupsForIndex();

        Task<bool> IsExistReportGroupByUrlName(string urlName);

        Task<ReportGroup?> GetReportGroupById(long id);

        Task<ReportGroup?> GetReportGroupByUrlName(string urlName);

        Task AddReportGroup(ReportGroup reportGroup);

        void UpdateReportGroup(ReportGroup reportGroup);

        Task<List<SelectListItem>> SelectedReportGroupId();

        #endregion

        Task SaveChanges();

        #endregion
    }
}
