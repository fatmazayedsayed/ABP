using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using JawdaProductCRUD.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace JawdaProductCRUD.Web.Pages.Products
{
    public class IndexModel : PageModel
    {
        public List<SelectListItem> Categories { get; set; }
        public Guid CategoryID { get; set; }

        private readonly IProductAppService _ProductAppService;

        [BindProperty]
        public CategoryProductViewModel CategoryProduct { get; set; }
        public IndexModel(
           IProductAppService ProductAppService)
        {
            _ProductAppService = ProductAppService;
        }
        public async Task OnGet()
        {
            CategoryProduct = new CategoryProductViewModel();

            var authorLookup = await _ProductAppService.GetCategoryLookupAsync();
            Categories = new List<SelectListItem>();
            Categories.Add(new SelectListItem { Text = "--------", Value = "0", Selected = true });

            Categories.AddRange(authorLookup.Items
                .Select(x => new SelectListItem(x.title, x.Id.ToString()))
                .ToList());

        }

        public class CategoryProductViewModel
        {
            [SelectItems(nameof(Categories))]
            [DisplayName("Category")]
            public Guid CategoryID { get; set; }
        }
    }
}
