using Microsoft.AspNetCore.Mvc.Rendering;
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

        Task<Report?> GetSpecialReportForIndex(string groupUrl);

        Task<List<Report>> GetReportsForIndex(string groupUrl);

        Task<List<Report>> GetTopReportsForIndex(string groupUrl);

        Task<List<Report>> GetSpecialReportsForIndex(string groupUrl);

        Task<List<Report>> GetRelatedReportsForIndex(string groupUrl, long reportId);

        Task<Report?> GetReportById(long id);

        Task AddReport(Report report);

        void UpdateReport(Report report);

        #endregion

        #region Group Reports

        Task<IQueryable<ReportGroup>> GetReportGroupsQuery();

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
