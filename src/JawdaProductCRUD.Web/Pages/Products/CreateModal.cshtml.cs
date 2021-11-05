using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JawdaProductCRUD.DTO.Products;
using JawdaProductCRUD.IServices;
using JawdaProductCRUD.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace JawdaProductCRUD.Web.Pages.Products
{
    public class CreateModalModel : JawdaProductCRUDPageModel
    {
        [BindProperty]
        public CreateProductViewModel Product { get; set; }

        public List<SelectListItem> Categories { get; set; }

        private readonly IProductAppService _ProductAppService;

        public CreateModalModel(
            IProductAppService ProductAppService)
        {
            _ProductAppService = ProductAppService;
        }

        public async Task OnGetAsync()
        {
            Product = new CreateProductViewModel();

            var authorLookup = await _ProductAppService.GetCategoryLookupAsync();
            Categories = authorLookup.Items
                .Select(x => new SelectListItem(x.title, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _ProductAppService.CreateAsync(
                ObjectMapper.Map<CreateProductViewModel, CreateUpdateProductDto>(Product)
                );
            return NoContent();
        }

        public class CreateProductViewModel
        {
            [SelectItems(nameof(Categories))]
            [DisplayName("Category")]
            public Guid CategoryID { get; set; }

            [Required]
            [StringLength(128)]
            public string title { get; set; }

            [Required]
            [StringLength(128)]
            public string description { get; set; }
            [Required]
            [StringLength(128)]
            public string picture { get; set; }

            [Required]
            public float price { get; set; }
        }
    }
}