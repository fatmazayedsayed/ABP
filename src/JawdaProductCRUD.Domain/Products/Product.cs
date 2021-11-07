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
        public string title_en { get; set; }
        public string description_en { get; set; }
        public string title_ar { get; set; }
        public string description_ar { get; set; }
        public float price { get; set; }
        public Guid CategoryID { get; set; }
        public string picture { get; set; }
    }
}
