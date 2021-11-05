using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace JawdaProductCRUD.DTO.Categories
{
    public class CategoryLookupDto : EntityDto<Guid>
    {
        public string title { get; set; }
    }
}
