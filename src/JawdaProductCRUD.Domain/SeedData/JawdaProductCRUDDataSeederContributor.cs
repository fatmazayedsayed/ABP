using JawdaProductCRUD.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace JawdaProductCRUD.SeedData
{
    public class JawdaProductCRUDDataSeederContributor
           : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Category, Guid> _categoryRepository;
        public JawdaProductCRUDDataSeederContributor(
           IRepository<Category, Guid> categoryRepository
           )
        {
            _categoryRepository = categoryRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _categoryRepository.GetCountAsync() <= 0)
            {
                await _categoryRepository.InsertAsync(
                    new Category
                    {
                        title = "Food"
                    },
                    autoSave: true
                );

                await _categoryRepository.InsertAsync(
                     new Category
                     {
                         title = "Book"
                     },
                     autoSave: true
                 );
                await _categoryRepository.InsertAsync(
                   new Category
                   {
                       title = "Islamic"
                   },
                   autoSave: true
               );
            }
        }
    }
}
