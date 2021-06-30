using ClinicServicesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.DataConnect;

namespace ClinicServicesWebAPI.Services
{
    public class vFeedMedicineServices : IvFeedMedicine
    {
        private ClinicContext context;
        public vFeedMedicineServices(ClinicContext context)
        {
            this.context = context;
        }
     

        public async Task<IEnumerable<vFeedMedicines>> GetIvFeedMedicine()
        {
            var a = from g in context.Feedback
                    join c in context.Medicines
                    on g.MedicineID equals c.MedicineID
                    select new vFeedMedicines { Feedback = g, Medicines = c, KeyID = g.AccountID };
            return a.ToList();
        }

      
    }
}
