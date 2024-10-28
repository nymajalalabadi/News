using Microsoft.AspNetCore.Mvc.Rendering;
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


        #endregion

        #region Reports Group

        Task<List<SelectListItem>> SelectedReportGroupId();

        #endregion

        #endregion
    }
}
