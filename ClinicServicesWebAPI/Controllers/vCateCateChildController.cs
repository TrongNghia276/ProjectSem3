
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
    public class vCateCateChildController : ControllerBase
    {
        private IvCateCateChild ivCateCateChild;
        public vCateCateChildController(IvCateCateChild ivCateCateChild)
        {
            this.ivCateCateChild = ivCateCateChild;
        }
        [HttpGet()]
        public async Task<IEnumerable<vCateCateChild>> GetIvCateCateChild()
        {
            return await ivCateCateChild.GetIvCateCateChild();
        }

     
    }
}

