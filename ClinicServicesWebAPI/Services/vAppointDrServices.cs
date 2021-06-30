using ClinicServicesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.DataConnect;

namespace ClinicServicesWebAPI.Services
{
    public class vAppointDrServices : IvAppointDr
    {
        private ClinicContext context;
        public vAppointDrServices(ClinicContext context)
        {
            this.context = context;
        }
     

        public async Task<IEnumerable<vAppointDr>> GetIvAppointDr()
        {
            var a = from g in context.Appointment
                    join c in context.DoctorDetail
                    on g.DoctorID equals c.DoctorID
                    select new vAppointDr { Appointment = g, DoctorDetail = c, KeyID = g.DoctorID };
            return a.ToList();
        }

       
    }
}
