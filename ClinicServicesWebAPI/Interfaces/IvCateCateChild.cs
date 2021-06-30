using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.Models;

namespace ClinicServicesWebAPI.Services
{
   public interface IvCateCateChild
    {
        Task<IEnumerable<vCateCateChild>> GetIvCateCateChild();
      
    }
}
