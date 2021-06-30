using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ClinicServicesWebAPI.Models;
using ClinicServicesWebAPI.DataConnect;
using Microsoft.EntityFrameworkCore;

using ClinicServicesWebAPI.Models;
using ClinicServicesWebAPI.Services;
namespace ClinicServicesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vDocAccsController : ControllerBase
    {
       
        private IDoctorA iseminar;
        public vDocAccsController(IDoctorA iseminar)
        {
            this.iseminar = iseminar;
        }
        [HttpGet()]
        public async Task<IEnumerable<vDocAcc>> GetIDoctorA()
        {
            return await iseminar.GetIDoctorA();
        }
    }
}
