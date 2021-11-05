using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace JawdaProductCRUD.Products
{
   public class Product:AuditedAggregateRoot<Guid>
    {
        public string title { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public Guid CategoryID { get; set; }
        public string picture { get; set; }
    }
}
