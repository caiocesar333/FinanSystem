using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceFinancialSystem : IServiceFinancialSystem
    {
        private readonly FinancialSystemInterface _interfaceFinancialSystem;
        public ServiceFinancialSystem(FinancialSystemInterface interfaceFinancialSystem) 
        {
            _interfaceFinancialSystem = interfaceFinancialSystem;
        }

        public async Task AddFinancialSystem(FinancialSystem financialSystem)
        {
            var valid = financialSystem.ValidatePropertyString(financialSystem.Name, "Name");

            if (valid) 
            {
                var date = DateTime.Now;

                financialSystem.CloseDay = 1;
                financialSystem.Year = date.Year;
                financialSystem.Month = date.Month;
                financialSystem.YearCopy = date.Year;
                financialSystem.MonthCopy = date.Month;
                financialSystem.GenerateCopyDespise = true;

                await _interfaceFinancialSystem.Add(financialSystem);

            }
        }

        public async Task UpdateFinancialSystem(FinancialSystem financialSystem)
        {
            var valid = financialSystem.ValidatePropertyString(financialSystem.Name, "Name");

            if (valid)
            {
                financialSystem.CloseDay = 1;
                await _interfaceFinancialSystem.Update(financialSystem);    

            }
        }
    }
}
