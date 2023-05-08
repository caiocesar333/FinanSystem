using Domain.Interfaces.ICategory;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceCategory : IServiceCategory
    {

        private readonly CategoryInterface _categoryInterface;

        public ServiceCategory(CategoryInterface categoryInterface) 
        {
            _categoryInterface = categoryInterface;
        }    
        public async Task AddCategory(Category category)
        {
            var valid = category.ValidatePropertyString(category.Name, "Name");
            if (valid) 
            {
                await _categoryInterface.Add(category);
            }
        }

        public async Task UpdateCategory(Category category)
        {
            var valid = category.ValidatePropertyString(category.Name, "Name");
            if (valid)
            {
                await _categoryInterface.Update(category);
            }
        }
    }
}
