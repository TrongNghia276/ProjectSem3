
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
    public class vCateChildMedicineController : ControllerBase
    {
        private IvCateChildMedicine ivCateChildMedicine;
        public vCateChildMedicineController(IvCateChildMedicine ivCateChildMedicine)
        {
            this.ivCateChildMedicine = ivCateChildMedicine;
        }
        [HttpGet()]
        public async Task<IEnumerable<vCateChildMedicines>> GetIvCateChildMedicine()
        {
            return await ivCateChildMedicine.GetIvCateChildMedicine();
        }

     
    }
}

