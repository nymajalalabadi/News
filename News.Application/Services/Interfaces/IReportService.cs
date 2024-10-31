using Microsoft.AspNetCore.Mvc.Rendering;
using News.Domain.ViewModels.ReportGroups;
using News.Domain.ViewModels.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Services.Interfaces
{
    public interface IReportService
    {
        #region Methods

        #region Reports

        Task<FilterReportsViewModel> GetFilterReports(FilterReportsViewModel filter);

        Task<CreateReportResult> CreateReport(CreateReportViewModel report);

        Task<EditReportViewModel> GetReportForEdit(long reportId);

        Task<EditReportResult> EditReport(EditReportViewModel report);

        Task<DetailsReportViewModel> DetailsReport(long reportId);

        Task<bool> DeleteReport(long reportId);

        #endregion

        #region Reports Group

        Task<List<SelectListItem>> SelectedReportGroupId();

        Task<FilterReportGroupsViewModel> GetFilterReportGroups(FilterReportGroupsViewModel filter);

        Task<CreateReportGroupResult> CreateReportGroup(CreateReportGroupViewModel reportGroup);

        Task<EditReportGroupViewModel> GetReportGroupForEdit(long reportGroupId);

        Task<EditReportGroupResult> EditReportGroup(EditReportGroupViewModel reportGroup);

        Task<DetailsReportGroupViewModel> DetailsReportGroup(long reportGroupId);

        Task<bool> DeleteReportGroup(long reportGroupId);

        #endregion

        #endregion
    }
}
