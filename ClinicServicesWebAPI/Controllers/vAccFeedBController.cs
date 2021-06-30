
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
    public class vAccFeedBController : ControllerBase
    {
        private IvAccFeedB ivAccFeedB;
        public vAccFeedBController(IvAccFeedB ivAccFeedB)
        {
            this.ivAccFeedB = ivAccFeedB;
        }
        [HttpGet()]
        public async Task<IEnumerable<vAccFeedB>> GetIvAccFeedB()
        {
            return await ivAccFeedB.GetIvAccFeedB();
        }

     
    }
}

