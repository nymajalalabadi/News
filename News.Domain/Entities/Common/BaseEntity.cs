using System.ComponentModel.DataAnnotations;

namespace News.Domain.Entities.Common
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public bool IsDelete { get; set; } = false;

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
    }
}
