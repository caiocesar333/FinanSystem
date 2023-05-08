using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IDespise
{
    public interface DespiseInterface : GenericInterface<Despise>
    {

        Task<IList<Despise>> ListUserDespises(string userEmail);

        Task<IList<Despise>> ListUserDespisesNotPayedLastMonth(string userEmail);

    }
}
