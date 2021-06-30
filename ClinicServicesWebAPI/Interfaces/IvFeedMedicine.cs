using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.Models;

namespace ClinicServicesWebAPI.Services
{
   public interface IvFeedMedicine
    {
        Task<IEnumerable<vFeedMedicines>> GetIvFeedMedicine();
      
    }
}
