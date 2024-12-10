using News.Domain.Entities.Account;
using News.Domain.Entities.Galleries;
using News.Domain.Entities.Reports;

namespace News.Domain.ViewModels.Footer
{
    public class FooterViewModel
    {
        public IEnumerable<Report> Reports { get; set; } = default!;

        public IEnumerable<Comment> Comments { get; set; } = default!;

        public IEnumerable<Image> Images { get; set; } = default!;
    }
}
