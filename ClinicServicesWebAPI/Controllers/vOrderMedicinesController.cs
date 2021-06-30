
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
    public class vOrderMedicinesController : ControllerBase
    {
        private IvOrderMedicine ivOrderMedicine;
        public vOrderMedicinesController(IvOrderMedicine ivOrderMedicine)
        {
            this.ivOrderMedicine = ivOrderMedicine;
        }
        [HttpGet()]
        public async Task<IEnumerable<vOrderMedicines>> GetIvOrderMedicine()
        {
            return await ivOrderMedicine.GetIvOrderMedicine();
        }

     
    }
}

