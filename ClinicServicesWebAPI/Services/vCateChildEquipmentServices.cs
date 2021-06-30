using ClinicServicesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.DataConnect;

namespace ClinicServicesWebAPI.Services
{
    public class vCateChildEquipmentServices : IvCateChildEquipment
    {
        private ClinicContext context;
        public vCateChildEquipmentServices(ClinicContext context)
        {
            this.context = context;
        }
     

        public async Task<IEnumerable<vCateChildEquipments>> GetIvCateChildEquipment()
        {
            var a = from g in context.CategoryChild
                    join c in context.MedicalEquipments
                    on g.CategoryChild_ID equals c.CategoryChild_ID
                    select new vCateChildEquipments { CategoryChild = g, MedicalEquipments = c, KeyID = g.CategoryChild_ID };
            return a.ToList();
        }

        
    }
}
