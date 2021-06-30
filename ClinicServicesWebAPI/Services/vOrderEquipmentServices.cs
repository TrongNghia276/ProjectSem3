using ClinicServicesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.DataConnect;

namespace ClinicServicesWebAPI.Services
{
    public class vOrderEquipmentServices : IvOrderEquipment
    {
        private ClinicContext context;
        public vOrderEquipmentServices(ClinicContext context)
        {
            this.context = context;
        }
     

        public async Task<IEnumerable<vOrderEquipments>> GetIvOrderEquipment()
        {
            var a = from g in context.Orders
                    join c in context.MedicalEquipments
                    on g.Medi_Equip_ID equals c.Medi_Equip_ID
                    select new vOrderEquipments { Orders = g, MedicalEquipments = c, KeyID = g.AccountID };
            return a.ToList();
        }

       
    }
}
