using ClinicServicesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.DataConnect;

namespace ClinicServicesWebAPI.Services
{
    public class vAccOrderServices : IvAccOrder
    {
        private ClinicContext context;
        public vAccOrderServices(ClinicContext context)
        {
            this.context = context;
        }
    
        public async Task<IEnumerable<vAccOrder>> GetIvAccOrder()
        {
            var a = from g in context.Accounts
                    join c in context.Orders
                    on g.AccountID equals c.AccountID
                    select new vAccOrder { Accounts = g, Orders = c, KeyID = g.AccountID };
            return a.ToList();
        }
    }
}
