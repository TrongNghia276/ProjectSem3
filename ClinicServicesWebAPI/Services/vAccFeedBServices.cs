using ClinicServicesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.DataConnect;

namespace ClinicServicesWebAPI.Services
{
    public class vAccFeedBServices : IvAccFeedB
    {
        private ClinicContext context;
        public vAccFeedBServices(ClinicContext context)
        {
            this.context = context;
        }
     

        public async Task<IEnumerable<vAccFeedB>> GetIvAccFeedB()
        {
            var a = from g in context.Accounts
                    join c in context.Feedback
                    on g.AccountID equals c.AccountID
                    select new vAccFeedB { accounts = g, feedback = c, KeyID = g.AccountID };
            return a.ToList();
        }
    }
}
