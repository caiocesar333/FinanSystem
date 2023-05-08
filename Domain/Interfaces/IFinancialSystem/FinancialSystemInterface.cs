using Domain.Interfaces.Generics;
using Entities.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IFinancialSystem
{
    public interface FinancialSystemInterface : GenericInterface<FinancialSystem>
    {

        Task<IList<FinancialSystem>> ListUserSystem( string userEmail);
    }
}
