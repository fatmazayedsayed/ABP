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
    public class EditModalModel : JawdaProductCRUDPageModel
    {
        [BindProperty]
        public EditCategoryViewModel Category { get; set; }

        private readonly ICategoryAppService _CategoryAppService;

        public EditModalModel(ICategoryAppService CategoryAppService)
        {
            _CategoryAppService = CategoryAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var categoryDto = await _CategoryAppService.GetAsync(id);
            Category = ObjectMapper.Map<CategoryDto, EditCategoryViewModel>(categoryDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _CategoryAppService.UpdateAsync(
                Category.Id,
                ObjectMapper.Map<EditCategoryViewModel, CreateUpdateCategoryDto>(Category)
            );

            return NoContent();
        }

        public class EditCategoryViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [Required]
             public string title { get; set; }

 
        }
    }
}

