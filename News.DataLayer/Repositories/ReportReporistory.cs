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
            return _context.Reports
                .Include(r => r.ReportGroup)
                .Where(u => !u.IsDelete && u.IsSuccess).AsQueryable();
        }

        public async Task<IQueryable<Report>> GetHotNewsReportsQuery()
        {
            return _context.Reports
                .Include(r => r.ReportGroup)
                .Where(u => !u.IsDelete && u.IsSuccess && u.IsHotNews).AsQueryable();
        }

        public async Task<Report?> GetSpecialReportForIndex(string groupUrl)
        {
            return await _context.Reports
                .Include(r => r.ReportGroup)
                .OrderByDescending(r => r.CreateDate)
                .Where(r => r.IsSuccess && r.ReportGroup.UrlName == groupUrl)
                .FirstOrDefaultAsync();
        }

        public async Task<Report?> GetHotNewsReportForIndex()
        {
            return await _context.Reports
                .Include(r => r.ReportGroup)
                .OrderByDescending(r => r.HotNewsDate)
                .Where(r => r.IsSuccess && r.IsHotNews == true)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Report>> GetLastReportsForIndex()
        {
            return await _context.Reports
               .Include(r => r.ReportGroup)
               .OrderByDescending(r => r.CreateDate)
               .Where(r => r.IsSuccess && !r.IsDelete)
               .Take(15)
               .ToListAsync();
        }

        public async Task<List<Report>> GetReportsForFooter()
        {
            return await _context.Reports
                .Include(r => r.ReportGroup)
                .OrderByDescending(r => r.CreateDate)
                .Where(r => r.IsSuccess && !r.IsDelete)
                .Take(5)
                .ToListAsync();
        }

        public async Task<List<Report>> GetReportsForIndex(string groupUrl)
        {
            return await _context.Reports
                .Include(r => r.ReportGroup)
                .OrderByDescending(r => r.CreateDate)
                .Where(r => r.IsSuccess && !r.IsDelete && r.ReportGroup.UrlName == groupUrl)
                .Take(4)
                .ToListAsync();
        }

        public async Task<List<Report>> GetTopReportsForIndex(string groupUrl)
        {
            return await _context.Reports
                .Include(r => r.ReportGroup)
                .OrderByDescending(r => r.CreateDate)
                .Where(r => r.IsSuccess && r.ReportGroup.UrlName != groupUrl)
                .Take(4)
                .ToListAsync();
        }

        public async Task<List<Report>> GetSpecialReportsForIndex(string groupUrl)
        {
            return await _context.Reports
                .Include(r => r.ReportGroup)
                .OrderByDescending(r => r.CreateDate)
                .Where(r => r.IsSuccess && r.ReportGroup.UrlName == groupUrl)
                .Skip(1)
                .Take(4)
                .ToListAsync();
        }

        public async Task<List<Report>> GetRelatedReportsForIndex(string groupUrl, long reportId)
        {
            return await _context.Reports
                .Include(r => r.ReportGroup)
                .OrderByDescending(r => r.Visit)
                .Where(r => r.IsSuccess && r.ReportGroup.UrlName == groupUrl && r.Id != reportId)
                .ToListAsync();
        }

        public async Task<List<Report>> GetHotNewsReportsForIndex()
        {
            return await _context.Reports
                .Include(r => r.ReportGroup)
                .OrderByDescending(r => r.HotNewsDate)
                .Where(r => r.IsSuccess && r.IsHotNews == true)
                .Skip(1)
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

        public async Task<List<ReportGroup>> GetReportGroupsForIndex()
        {
            return await _context.ReportGroups
                .OrderByDescending(u => u.CreateDate)
                .Where(u => !u.IsDelete)
                .Take(10)
                .ToListAsync();
        }

        public async Task<List<ReportGroup>> GetAllReportGroupsForIndex()
        {
            return await _context.ReportGroups
                .OrderByDescending(u => u.CreateDate)
                .Where(u => !u.IsDelete)
                .ToListAsync();
        }

        public async Task<bool> IsExistReportGroupByUrlName(string urlName)
        {
            return await _context.ReportGroups.AnyAsync(g => g.UrlName.Equals(urlName));
        }

        public async Task<ReportGroup?> GetReportGroupById(long id)
        {
            return await _context.ReportGroups
                .FirstOrDefaultAsync(r => r.Id.Equals(id));
        }

        public async Task<ReportGroup?> GetReportGroupByUrlName(string urlName)
        {
            return await _context.ReportGroups
                .FirstOrDefaultAsync(r => r.UrlName.Equals(urlName));
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
