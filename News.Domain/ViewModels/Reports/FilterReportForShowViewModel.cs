﻿using News.Domain.Entities.Reports;
using News.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Reports
{
    public class FilterReportForShowViewModel : Paging<Report>
    {
        public string? UrlName { get; set; } = default!;

        public string? GroupName { get; set; } = default!;
    }
}
