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

        Task<Report?> GetReportById(long id);

        Task AddReport(Report report);

        void UpdateReport(Report report);

        #endregion

        #region Group Reports

        Task<List<SelectListItem>> SelectedReportGroupId();

        #endregion

        Task SaveChanges();

        #endregion
    }
}
