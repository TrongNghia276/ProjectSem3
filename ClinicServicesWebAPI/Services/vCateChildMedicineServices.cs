using ClinicServicesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.DataConnect;

namespace ClinicServicesWebAPI.Services
{
    public class vCateChildMedicineServices : IvCateChildMedicine
    {
        private ClinicContext context;
        public vCateChildMedicineServices(ClinicContext context)
        {
            this.context = context;
        }
     

        public async Task<IEnumerable<vCateChildMedicines>> GetIvCateChildMedicine()
        {
            var a = from g in context.CategoryChild
                    join c in context.Medicines
                    on g.CategoryChild_ID equals c.CategoryChild_ID
                    select new vCateChildMedicines { CategoryChild = g, Medicines = c, KeyID = g.CategoryChild_ID };
            return a.ToList();
        }

       
    }
}
