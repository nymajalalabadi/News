using News.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Reports
{
    public class ReportsListForShowIndex
    {
        public List<Report> Reports { get; set; } = default!;

        public ReportGroup ReportGroup { get; set; } = default!;
    }
}
