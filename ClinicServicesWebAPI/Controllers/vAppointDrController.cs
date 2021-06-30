
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
    public class vAppointDrController : ControllerBase
    {
        private IvAppointDr ivAppointDr;
        public vAppointDrController(IvAppointDr ivAppointDr)
        {
            this.ivAppointDr = ivAppointDr;
        }
        [HttpGet()]
        public async Task<IEnumerable<vAppointDr>> GetIvAppointDr()
        {
            return await ivAppointDr.GetIvAppointDr();
        }

     
    }
}

