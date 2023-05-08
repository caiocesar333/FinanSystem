using Domain.Interfaces.IUserFinancialSystem;
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
    public class UserFinancialSystemRepository : GenericsRepositories<UserFinancialSystem>, UserFinancialSystemInterface
    {

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;


        public UserFinancialSystemRepository()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();

        }
        public async Task DeleteUsers(List<UserFinancialSystem> users)
        {
            using (var bank = new ContextBase(_OptionsBuilder))
            {
                bank.UserFinancialSystem.RemoveRange(users);

                await bank.SaveChangesAsync();
            }
        }

        public async Task<UserFinancialSystem> GetUserByEmail(string userEmail)
        {
            using (var bank = new ContextBase(_OptionsBuilder))
            {
                return await bank.UserFinancialSystem.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Equals(userEmail));
            }
        }

        public async Task<IList<UserFinancialSystem>> ListFinancialSystemUsers(int idSystem)
        {
            using (var bank = new ContextBase(_OptionsBuilder))
            {
                return await bank.UserFinancialSystem.Where(s => s.IdSystem == idSystem).AsNoTracking().ToListAsync();
            }
        }
    }
}
