using Microsoft.Extensions.DependencyInjection;
using News.Application.Services.Implementations;
using News.Application.Services.Interfaces;
using News.DataLayer.Repositories;
using News.Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.LoC
{
    public class DependencyContainer
    {
        public static void RejosterService(IServiceCollection services)
        {
            #region Reporistory

            services.AddScoped<IReportReporistory, ReportReporistory>();

            #endregion

            #region Service

            services.AddScoped<IReportService, ReportService>();

            #endregion
        }
    }
}
