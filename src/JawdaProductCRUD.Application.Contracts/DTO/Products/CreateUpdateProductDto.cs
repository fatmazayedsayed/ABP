using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JawdaProductCRUD.DTO.Products
{
    public class CreateUpdateProductDto
    {
        [Required]
        [StringLength(128)]
        public string title_ar { get; set; }

        // [Required]
        [StringLength(5000)]
        public string description_ar { get; set; }

        [Required]
        [StringLength(128)]
        public string title_en { get; set; }

        // [Required]
        [StringLength(5000)]
        public string description_en { get; set; }
        [Required]
        public float price { get; set; }
        //[Required]
        public Guid CategoryID { get; set; }
        [Required]
        public string picture { get; set; }
    }

}
