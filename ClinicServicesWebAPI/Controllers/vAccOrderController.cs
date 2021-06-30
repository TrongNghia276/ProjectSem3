
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
    public class vAccOrderController : ControllerBase
    {
        private IvAccOrder ivAccOrder;
        public vAccOrderController(IvAccOrder ivAccOrder)
        {
            this.ivAccOrder = ivAccOrder;
        }
        [HttpGet()]
        public async Task<IEnumerable<vAccOrder>> GetIvAccOrder()
        {
            return await ivAccOrder.GetIvAccOrder();
        }

     
    }
}

