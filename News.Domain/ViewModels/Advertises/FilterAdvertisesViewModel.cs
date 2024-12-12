using News.Domain.Entities.Advertises;
using News.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Advertises
{
    public class FilterAdvertisesViewModel : Paging<Advertise>
    {
        public string? AdsName { get; set; }
    }
}
