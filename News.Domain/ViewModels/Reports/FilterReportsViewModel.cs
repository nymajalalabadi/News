using News.Domain.Entities.Reports;
using News.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Reports
{
    public class FilterReportsViewModel : Paging<Report>
    {
        public string? Title { get; set; } = default!;
    }
}
