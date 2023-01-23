using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claim.Domain.Commons
{
    public class BaseEntity<TKey>
    {
        public  TKey Id { get; set; }
        public long CreatedBy { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public long? LastModifiedBy { get; set; }

        public DateTime? DateLastModified { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime? DateRemoved { get; set; }
        public long RemovedBy { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<long>
    {

    }
}
