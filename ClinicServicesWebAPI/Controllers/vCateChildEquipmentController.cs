
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
    public class vCateChildEquipmentController : ControllerBase
    {
        private IvCateChildEquipment ivCateChildEquipment;
        public vCateChildEquipmentController(IvCateChildEquipment ivCateChildEquipment)
        {
            this.ivCateChildEquipment = ivCateChildEquipment;
        }
        [HttpGet()]
        public async Task<IEnumerable<vCateChildEquipments>> GetIvCateChildEquipment()
        {
            return await ivCateChildEquipment.GetIvCateChildEquipment();
        }

     
    }
}

