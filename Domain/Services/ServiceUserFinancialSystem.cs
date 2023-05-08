using Domain.Interfaces.IServices;
using Domain.Interfaces.IUserFinancialSystem;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceUserFinancialSystem : IServiceUserFinancialSystem
    {
        private readonly UserFinancialSystemInterface _userFinancialSystemInterface; 
        public ServiceUserFinancialSystem(UserFinancialSystemInterface userFinancialSystemInterface) 
        {
            _userFinancialSystemInterface = userFinancialSystemInterface;
        }

        public async Task RegisterUsersOnSystem(UserFinancialSystem userFinancialSystem)
        {
            await _userFinancialSystemInterface.Add(userFinancialSystem);
        }
    }
}
