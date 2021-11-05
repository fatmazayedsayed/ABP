using AutoMapper;
using JawdaProductCRUD.Categories;
using JawdaProductCRUD.DTO.Categories;
using JawdaProductCRUD.DTO.Products;
using JawdaProductCRUD.Products;
using static JawdaProductCRUD.Web.Pages.Categories.CreateModalModel;
using static JawdaProductCRUD.Web.Pages.Categories.EditModalModel;
using static JawdaProductCRUD.Web.Pages.Products.CreateModalModel;
using static JawdaProductCRUD.Web.Pages.Products.EditModalModel;

namespace JawdaProductCRUD.Web
{
    public class JawdaProductCRUDWebAutoMapperProfile : Profile
    {
        public JawdaProductCRUDWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
         //product
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CreateUpdateProductDto, Product>().ReverseMap();
             CreateMap<CreateProductViewModel, CreateUpdateProductDto>().ReverseMap();
            CreateMap<ProductDto, EditProductViewModel>();
            CreateMap<EditProductViewModel, CreateUpdateProductDto>();

            //category
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CreateUpdateCategoryDto, Category>().ReverseMap();
            CreateMap<Category, CategoryLookupDto>().ReverseMap();
            CreateMap<CreateCategoryViewModel, CreateUpdateCategoryDto>().ReverseMap();
            CreateMap<CategoryDto, EditCategoryViewModel>();
            CreateMap<EditCategoryViewModel,  CreateUpdateCategoryDto>();

        }
    }
}
