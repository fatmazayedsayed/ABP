using AutoMapper;
using JawdaProductCRUD.Categories;
using JawdaProductCRUD.DTO.Categories;
using JawdaProductCRUD.DTO.Products;
using JawdaProductCRUD.Products;

namespace JawdaProductCRUD
{
    public class JawdaProductCRUDApplicationAutoMapperProfile : Profile
    {
        public JawdaProductCRUDApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CreateUpdateProductDto, Product>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CreateUpdateCategoryDto, Category>().ReverseMap();
            CreateMap<Category, CategoryLookupDto>();

        }
    }
}
