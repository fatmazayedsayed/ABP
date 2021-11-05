using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace JawdaProductCRUD.Categories
{
   public class Category : AuditedAggregateRoot<Guid>
    {
        public string title { get; set; }

    }
}
