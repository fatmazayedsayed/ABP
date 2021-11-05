using JawdaProductCRUD.Categories;
using JawdaProductCRUD.DTO.Categories;
using JawdaProductCRUD.DTO.Categories;
using JawdaProductCRUD.IServices;
using JawdaProductCRUD.Permissions;
using JawdaProductCRUD.Categories;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using JawdaProductCRUD.Permissions;

namespace JawdaProductCRUD.Services
{
    [Authorize(JawdaProductCRUDPermissions.Categories.Default)]

    public class CategoryAppService :
          CrudAppService<
              Category, //The Category entity
              CategoryDto, //Used to show Categorys
              Guid, //Primary key of the Category entity
              PagedAndSortedResultRequestDto, //Used for paging/sorting
              CreateUpdateCategoryDto>, //Used to create/update a Category
          ICategoryAppService //implement the ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;
 
        public CategoryAppService(
      IRepository<Category, Guid> repository
   , ICategoryRepository categoryRepository)

      : base(repository)
        {
            _categoryRepository = categoryRepository;
            GetPolicyName = JawdaProductCRUDPermissions.Categories.Default;
            GetListPolicyName = JawdaProductCRUDPermissions.Categories.Default;
            CreatePolicyName = JawdaProductCRUDPermissions.Categories.Create;
            UpdatePolicyName = JawdaProductCRUDPermissions.Categories.Edit;
            DeletePolicyName = JawdaProductCRUDPermissions.Categories.Delete;
        }


    
        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"Category.{nameof(Category.title)}";
            }

            if (sorting.Contains("categoryTitle", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "categoryTitle",
                    "category.Title",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"Category.{sorting}";
        }

    }
}
