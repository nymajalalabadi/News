using Microsoft.EntityFrameworkCore;
using News.Domain.Entities.Account;
using News.Domain.Entities.Galleries;
using News.Domain.Entities.Hashtags;
using News.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataLayer.Context
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) { }

        #region DB Set

        public DbSet<Report> Reports { get; set; }

        public DbSet<ReportGroup> ReportGroups { get; set; }

        public DbSet<Hashtag> Hashtags { get; set; }

        public DbSet<Gallery> Galleries { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Comment> Comments { get; set; }

        #endregion
    }
}
