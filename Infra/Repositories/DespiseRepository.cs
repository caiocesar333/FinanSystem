using Domain.Interfaces.IDespise;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class DespiseRepository : GenericsRepositories<Despise>, DespiseInterface
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;


        public DespiseRepository() 
        {   
             _OptionsBuilder = new DbContextOptions<ContextBase>();
            
        }
        public async Task<IList<Despise>> ListUserDespises(string userEmail)
        {
            using ( var bank = new ContextBase(_OptionsBuilder))
            {
                return await (from s in bank.FinancialSystem
                              join c in bank.Category on s.Id equals c.IdSystem
                              join us in bank.UserFinancialSystem on s.Id equals us.IdSystem
                              join d in bank.Despise on c.Id equals d.IdCategory
                              where us.Email.Equals(userEmail) && s.Month == d.Month && s.Year == d.Year
                              select d).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Despise>> ListUserDespisesNotPayedLastMonth(string userEmail)
        {
            using (var bank = new ContextBase(_OptionsBuilder))
            {
                return await (from s in bank.FinancialSystem
                              join c in bank.Category on s.Id equals c.IdSystem
                              join us in bank.UserFinancialSystem on s.Id equals us.IdSystem
                              join d in bank.Despise on c.Id equals d.IdCategory
                              where us.Email.Equals(userEmail) && d.Month > DateTime.Now.Month && !d.IsPayed
                              select d).AsNoTracking().ToListAsync();
            }
        }
    }
}
