using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JawdaProductCRUD.DTO.Categories;
using JawdaProductCRUD.DTO.Products;
using JawdaProductCRUD.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace JawdaProductCRUD.Web.Pages.Products
{
    public class EditModalModel: JawdaProductCRUDPageModel
    {
        [BindProperty]
        public EditProductViewModel Product { get; set; }

        public List<SelectListItem> Categories { get; set; }

        private readonly IProductAppService _bookAppService;

        public EditModalModel(IProductAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var bookDto = await _bookAppService.GetAsync(id);
            Product = ObjectMapper.Map<ProductDto, EditProductViewModel>(bookDto);

            var authorLookup = await _bookAppService.GetCategoryLookupAsync();
            Categories = authorLookup.Items
                .Select(x => new SelectListItem(x.title, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.UpdateAsync(
                Product.Id,
                ObjectMapper.Map<EditProductViewModel, CreateUpdateProductDto>(Product)
            );

            return NoContent();
        }

        public class EditProductViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [SelectItems(nameof(Categories))]
            [DisplayName("Category")]
            public Guid CategoryID { get; set; }

            [Required]
            [StringLength(128)]
            public string title_ar { get; set; }
            [Required]
            [StringLength(128)]
            public string description_ar { get; set; }

            [Required]
            [StringLength(128)]
            public string title_en { get; set; }

            [Required]
            [StringLength(128)]
            public string description_en { get; set; }
            [Required]
            [StringLength(128)]
            public string picture { get; set; }
            [Required]
            public float price { get; set; }
        }
    }
}