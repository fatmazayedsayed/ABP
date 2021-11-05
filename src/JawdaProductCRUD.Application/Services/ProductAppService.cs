using JawdaProductCRUD.Categories;
using JawdaProductCRUD.DTO.Categories;
using JawdaProductCRUD.DTO.Products;
using JawdaProductCRUD.IServices;
using JawdaProductCRUD.Permissions;
using JawdaProductCRUD.Products;
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

namespace JawdaProductCRUD.Services
{
    [Authorize(JawdaProductCRUDPermissions.Products.Default)]

    public class ProductAppService :
          CrudAppService<
              Product, //The Product entity
              ProductDto, //Used to show Products
              Guid, //Primary key of the Product entity
              PagedAndSortedResultRequestDto, //Used for paging/sorting
              CreateUpdateProductDto>, //Used to create/update a Product
          IProductAppService //implement the IProductAppService
    {
        private readonly ICategoryRepository _categoryRepository;
 
        public ProductAppService(
      IRepository<Product, Guid> repository
   , ICategoryRepository categoryRepository)

      : base(repository)
        {
            _categoryRepository = categoryRepository;
            GetPolicyName = JawdaProductCRUDPermissions.Products.Default;
            GetListPolicyName = JawdaProductCRUDPermissions.Products.Default;
            CreatePolicyName = JawdaProductCRUDPermissions.Products.Create;
            UpdatePolicyName = JawdaProductCRUDPermissions.Products.Edit;
            DeletePolicyName = JawdaProductCRUDPermissions.Products.Delete;
        }


        public override async Task<ProductDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Product> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join Products and categorys
            var query = from product in queryable
                        join category in _categoryRepository on product.CategoryID equals category.Id
                        where product.Id == id
                        select new { product, category };

            //Execute the query and get the Product with category
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Product), id);
            }

            var ProductDto = ObjectMapper.Map<Product, ProductDto>(queryResult.product);
            ProductDto.CategoryTitle = queryResult.category.title;
            return ProductDto;
        }

        public override async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Product> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join Products and categorys
            var query = from product in queryable
                        join category in _categoryRepository on product.CategoryID equals category.Id
                        select new { product, category };

            //Paging
            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of ProductDto objects
            var ProductDtos = queryResult.Select(x =>
            {
                var ProductDto = ObjectMapper.Map<Product, ProductDto>(x.product);
                ProductDto.CategoryTitle = x.category.title;
                return ProductDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<ProductDto>(
                totalCount,
                ProductDtos
            );
        }

        public async Task<ListResultDto<CategoryLookupDto>> GetCategoryLookupAsync()
        {
            var categorys = await _categoryRepository.GetListAsync();

            return new ListResultDto<CategoryLookupDto>(
                ObjectMapper.Map<List<Category>, List<CategoryLookupDto>>(categorys)
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"product.{nameof(Product.title)}";
            }

            if (sorting.Contains("categoryTitle", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "categoryTitle",
                    "category.Title",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"product.{sorting}";
        }

    }
}
