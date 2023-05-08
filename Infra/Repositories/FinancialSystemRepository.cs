using Domain.Interfaces.IFinancialSystem;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class FinancialSystemRepository : GenericsRepositories<FinancialSystem>, FinancialSystemInterface
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;


        public FinancialSystemRepository()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();

        }
        public async Task<IList<FinancialSystem>> ListUserSystem(string userEmail)
        {
            using (var bank = new ContextBase(_OptionsBuilder))
            {
                return await (from s in bank.FinancialSystem
                              join us in bank.UserFinancialSystem on s.Id equals us.IdSystem
                              where us.Email.Equals(userEmail) 
                              select s).AsNoTracking().ToListAsync();
            }
        }
    }
}
