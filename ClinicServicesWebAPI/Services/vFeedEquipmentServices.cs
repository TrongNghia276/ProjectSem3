using ClinicServicesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.DataConnect;

namespace ClinicServicesWebAPI.Services
{
    public class vFeedEquipmentServices : IvFeedEquipment
    {
        private ClinicContext context;
        public vFeedEquipmentServices(ClinicContext context)
        {
            this.context = context;
        }
     

        public async Task<IEnumerable<vFeedEquipments>> GetIvFeedEquipment()
        {
            var a = from g in context.Feedback
                    join c in context.MedicalEquipments
                    on g.Medi_Equip_ID equals c.Medi_Equip_ID
                    select new vFeedEquipments { Feedback = g, MedicalEquipments = c, KeyID = g.AccountID };
            return a.ToList();
        }

       
    }
}
