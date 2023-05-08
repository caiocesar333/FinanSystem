using Domain.Interfaces.ICategory;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class CategoryRepository : GenericsRepositories<Category>, CategoryInterface
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public CategoryRepository()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();   
        }

        public async Task<IList<Category>> ListUserCategories(string userEmail)
        {
            using (var bank = new ContextBase(_OptionsBuilder))
            {
                return await (from s in bank.FinancialSystem 
                              join c in bank.Category on s.Id equals c.IdSystem
                              join us in bank.UserFinancialSystem on s.Id equals us.IdSystem
                              where us.Email.Equals(userEmail) && us.CurrentSystem
                              select c ).AsNoTracking().ToListAsync();

            }


        }

       
    }
}
