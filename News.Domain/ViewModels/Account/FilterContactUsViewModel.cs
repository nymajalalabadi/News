using News.Domain.Entities.Account;
using News.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Account
{
    public class FilterContactUsViewModel : Paging<ContactUs>
    {
        public string? Email { get; set; }

        public string? Name { get; set; }
    }
}
