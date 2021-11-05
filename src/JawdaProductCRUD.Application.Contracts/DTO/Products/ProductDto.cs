using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace JawdaProductCRUD.DTO.Products
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public string title { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public Guid CategoryID { get; set; }
        public string picture { get; set; }
        public string CategoryTitle { get; set; }
    }

}
