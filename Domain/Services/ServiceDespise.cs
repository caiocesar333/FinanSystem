using Domain.Interfaces.IDespise;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceDespise : IServiceDespise
    {
        private readonly DespiseInterface _despiseInterface;
        public ServiceDespise(DespiseInterface despiseInterface ) 
        {
            _despiseInterface = despiseInterface;
        }

        public async  Task AddDespise(Despise despise)
        {
            var date = DateTime.UtcNow;

            despise.DateRegister = date;
            despise.Year = date.Year;
            despise.Month = date.Month;

            var valid = despise.ValidatePropertyString(despise.Name, "Name");

            if (valid) 
            {
                await _despiseInterface.Add(despise);
            }
        }

        public async Task UpdateDespise(Despise despise)
        {
            var date = DateTime.UtcNow;

            despise.DateUpdate = date;

            if(despise.IsPayed) 
            {
                despise.DatePayment = date;
            }

            var valid = despise.ValidatePropertyString(despise.Name, "Name");

            if (valid)
            {
                await _despiseInterface.Update(despise);
            }
        }
    }
}
