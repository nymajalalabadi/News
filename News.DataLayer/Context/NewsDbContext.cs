using Microsoft.EntityFrameworkCore;
using News.Domain.Entities.Account;
using News.Domain.Entities.Advertises;
using News.Domain.Entities.Galleries;
using News.Domain.Entities.Hashtags;
using News.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public DbSet<Advertise> Advertises { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<Links> links { get; set; }

        public DbSet<Users> Users { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #region seed date

            var date = DateTime.MinValue;

            modelBuilder.Entity<Links>().HasData(new Links()
            {
                CreateDate = date,
                Id = 1,
                LinkAddress = "test",
                IsSuccess = true,
                LinkName = "test",
                LastUpdateDate = date
            });
    
            #endregion
                base.OnModelCreating(modelBuilder);
        }
    }
}
