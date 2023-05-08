using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUserFinancialSystem
{
    public interface UserFinancialSystemInterface : GenericInterface<UserFinancialSystem>
    {

        Task<IList<UserFinancialSystem>> ListFinancialSystemUsers(int idSystem);

        Task DeleteUsers (List<UserFinancialSystem> users);

        Task<UserFinancialSystem> GetUserByEmail (string userEmail);
    }
}
