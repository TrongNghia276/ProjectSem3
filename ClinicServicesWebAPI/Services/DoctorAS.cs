using ClinicServicesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.DataConnect;

namespace ClinicServicesWebAPI.Services
{
    public class DoctorAS : IDoctorA
    {
        private ClinicContext context;
        public DoctorAS(ClinicContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<vDocAcc>> GetIDoctorA()
        {
            var a = from g in context.Accounts
                    join c in context.DoctorDetail
                    on g.AccountID equals c.AccountID
                    select new vDocAcc { accounts = g, doctorDetail=c ,KeyID=g.AccountID};
            return a.ToList();
        }    
    }
}
