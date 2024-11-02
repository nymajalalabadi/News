using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using News.DataLayer.Context;
using News.Domain.Entities.Reports;
using News.Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataLayer.Repositories
{
    public class ReportReporistory : IReportReporistory
    {
        #region Constructor

        private readonly NewsDbContext _context;

        public ReportReporistory(NewsDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        #region Reports

        public async Task<IQueryable<Report>> GetReportsQuery()
        {
            return _context.Reports.Where(u => !u.IsDelete).AsQueryable();
        }

        public async Task<List<Report>> GetReportsForIndex(string groupUrl)
        {
            return await _context.Reports
                .Include(r => r.ReportGroup)
                .OrderByDescending(r => r.CreateDate)
                .Where(r => r.IsSuccess && r.ReportGroup.UrlName == groupUrl)
                .Take(4)
                .ToListAsync();
        }

        public async Task<Report?> GetReportById(long id)
        {
            return await _context.Reports
                .Include(u => u.ReportGroup)
                .FirstOrDefaultAsync(r => r.Id.Equals(id));
        }

        public async Task AddReport(Report report)
        {
            await _context.Reports.AddAsync(report);
        }

        public void UpdateReport(Report report)
        {
            _context.Reports.Update(report);
        }

        #endregion

        #region Group Reports

        public async Task<IQueryable<ReportGroup>> GetReportGroupsQuery()
        {
            return _context.ReportGroups.Where(u => !u.IsDelete).AsQueryable();
        }

        public async Task<ReportGroup?> GetReportGroupById(long id)
        {
            return await _context.ReportGroups
                .FirstOrDefaultAsync(r => r.Id.Equals(id));
        }

        public async Task AddReportGroup(ReportGroup reportGroup)
        {
            await _context.ReportGroups.AddAsync(reportGroup);
        }

        public void UpdateReportGroup(ReportGroup reportGroup)
        {
            _context.ReportGroups.Update(reportGroup);
        }

        public async Task<List<SelectListItem>> SelectedReportGroupId()
        {
            return await _context.ReportGroups
                .Where(p => !p.IsDelete)
                .Select(p => new SelectListItem()
                {
                    Text = p.GroupName,
                    Value = p.Id.ToString()
                })
                .ToListAsync();
        }

        #endregion

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
