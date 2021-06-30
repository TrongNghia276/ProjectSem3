
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.Models;
using ClinicServicesWebAPI.Services;
using ClinicServicesWebAPI.DataConnect;
using Microsoft.EntityFrameworkCore;

namespace ClinicServicesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vFeedMedicineController : ControllerBase
    {
        private IvFeedMedicine ivFeedMedicine;
        public vFeedMedicineController(IvFeedMedicine ivFeedMedicine)
        {
            this.ivFeedMedicine = ivFeedMedicine;
        }
        [HttpGet()]
        public async Task<IEnumerable<vFeedMedicines>> GetIvFeedMedicine()
        {
            return await ivFeedMedicine.GetIvFeedMedicine();
        }

     
    }
}

