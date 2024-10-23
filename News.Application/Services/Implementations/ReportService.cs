using News.Application.Services.Interfaces;
using News.DataLayer.Context;
using News.Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Services.Implementations
{
    public class ReportService : IReportService
    {
        #region Constructor

        private readonly IReportReporistory _reportReporistory;

        public ReportService(IReportReporistory reportReporistory)
        {
            _reportReporistory = reportReporistory;
        }

        #endregion

        #region Methods



        #endregion
    }
}
