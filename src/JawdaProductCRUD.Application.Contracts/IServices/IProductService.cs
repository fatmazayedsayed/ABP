using JawdaProductCRUD.DTO.Categories;
using JawdaProductCRUD.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace JawdaProductCRUD.IServices
{
    public  interface IProductAppService : ICrudAppService< //Defines CRUD methods
            ProductDto, //Used to show products
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateProductDto> //Used to create/update a book
    {
        Task<ListResultDto<CategoryLookupDto>> GetCategoryLookupAsync();

    }
}
