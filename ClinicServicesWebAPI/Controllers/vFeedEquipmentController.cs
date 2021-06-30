
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
    public class vFeedEquipmentController : ControllerBase
    {
        private IvFeedEquipment ivFeedEquipment;
        public vFeedEquipmentController(IvFeedEquipment ivFeedEquipment)
        {
            this.ivFeedEquipment = ivFeedEquipment;
        }
        [HttpGet()]
        public async Task<IEnumerable<vFeedEquipments>> GetIvFeedEquipment()
        {
            return await ivFeedEquipment.GetIvFeedEquipment();
        }

     
    }
}

