using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JawdaProductCRUD.DTO.Categories;
using JawdaProductCRUD.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JawdaProductCRUD.Web.Pages.Categories
{
    public class CreateModalModel : JawdaProductCRUDPageModel
    {
        [BindProperty]
        public CreateCategoryViewModel Category { get; set; }

        private readonly ICategoryAppService _CategoryAppService;

        public CreateModalModel(ICategoryAppService CategoryAppService)
        {
            _CategoryAppService = CategoryAppService;
        }

        public void OnGet()
        {
            Category = new CreateCategoryViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            var dto = ObjectMapper.Map<CreateCategoryViewModel, CreateUpdateCategoryDto>(Category);
            await _CategoryAppService.CreateAsync(dto);
            return NoContent();
        }

        public class CreateCategoryViewModel
        {
            [Required]
          //  [StringLength(CategoryConsts.MaxNameLength)]
            public string title { get; set; }

          
        }
    }
}
