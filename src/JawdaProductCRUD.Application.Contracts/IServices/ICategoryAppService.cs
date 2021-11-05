using JawdaProductCRUD.DTO.Categories;
using JawdaProductCRUD.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;
 using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace JawdaProductCRUD.IServices
{
    public  interface ICategoryAppService : ICrudAppService< //Defines CRUD methods
            DTO.Categories.CategoryDto, //Used to show products
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            DTO.Categories.CreateUpdateCategoryDto> //Used to create/update a book
    {
 
    }
}
