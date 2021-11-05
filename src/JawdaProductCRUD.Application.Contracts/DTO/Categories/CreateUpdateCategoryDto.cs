using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JawdaProductCRUD.DTO.Categories
{
    public class CreateUpdateCategoryDto
    {
        [Required]
        // [StringLength(128)]
        public string title { get; set; }

    }

}
