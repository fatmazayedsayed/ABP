using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace JawdaProductCRUD.DTO.Products
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public string title_ar { get; set; }
        public string description_ar { get; set; }

        public string title_en { get; set; }
        public string description_en { get; set; }
        public float price { get; set; }
        public Guid CategoryID { get; set; }
        public string picture { get; set; }
        public string CategoryTitle { get; set; }
    }

}
