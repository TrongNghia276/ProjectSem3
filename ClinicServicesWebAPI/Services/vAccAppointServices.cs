using ClinicServicesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.DataConnect;

namespace ClinicServicesWebAPI.Services
{
    public class vAccAppointService : IvAccApp
    {
        private ClinicContext context;
        public vAccAppointService(ClinicContext context)
        {
            this.context = context;
        }
     

        public async Task<IEnumerable<vAccAppoint>> GetIvAccApps()
        {
            var a = from g in context.Accounts
                    join c in context.Appointment
                    on g.AccountID equals c.AccountID
                    select new vAccAppoint { accounts = g, appointment = c, KeyID = g.AccountID };
            return a.ToList();
        }
    }
}
