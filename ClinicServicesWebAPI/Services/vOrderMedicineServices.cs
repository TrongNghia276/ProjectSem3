using ClinicServicesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.DataConnect;

namespace ClinicServicesWebAPI.Services
{
    public class vOrderMedicineServices : IvOrderMedicine
    {
        private ClinicContext context;
        public vOrderMedicineServices(ClinicContext context)
        {
            this.context = context;
        }
     

        public async Task<IEnumerable<vOrderMedicines>> GetIvOrderMedicine()
        {
            var a = from g in context.Orders
                    join c in context.Medicines
                    on g.MedicineID equals c.MedicineID
                    select new vOrderMedicines { Orders = g, Medicines = c, KeyID = g.AccountID };
            return a.ToList();
        }

      
    }
}
