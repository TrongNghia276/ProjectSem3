
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
    public class vOrderEquipmentsController : ControllerBase
    {
        private IvOrderEquipment ivOrderEquipment;
        public vOrderEquipmentsController(IvOrderEquipment ivOrderEquipment)
        {
            this.ivOrderEquipment = ivOrderEquipment;
        }
        [HttpGet()]
        public async Task<IEnumerable<vOrderEquipments>> GetIvOrderEquipment()
        {
            return await ivOrderEquipment.GetIvOrderEquipment();
        }

     
    }
}

