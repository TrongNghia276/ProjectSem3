
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
    public class vAccAppointsController : ControllerBase
    {
        private IvAccApp ivAccApp;
        public vAccAppointsController (IvAccApp ivAccApp)
        {
            this.ivAccApp = ivAccApp;
        }
        [HttpGet()]
        public async Task<IEnumerable<vAccAppoint>> GetIvAccApps()
        {
            return await ivAccApp.GetIvAccApps();
        }

     
    }
}

