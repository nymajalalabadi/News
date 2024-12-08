using News.Domain.Entities.Galleries;
using News.Domain.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Images
{
    public class ImagesAndReportGroupsViewModel
    {
        public IEnumerable<Image> Images { get; set; }

        public IEnumerable<ReportGroup> ReportGroups { get; set; }

    }
}
