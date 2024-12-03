using News.Domain.Entities.Account;
using News.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.ViewModels.Account
{
    public class FilterCommentViewModel : Paging<Comment>
    {
        public string? Email { get; set; } = default!;
    }
}
