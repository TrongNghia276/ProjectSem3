using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sem3Project.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Sem3Project.Controllers
{
    public class MedicalEquipmentsController : Controller
    {
        private string url = "http://localhost:61505/api/MedicalEquipments/";
        private HttpClient httpClient = new HttpClient();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var model = JsonConvert.DeserializeObject<MedicalEquipments>(httpClient.GetStringAsync(url + id).Result);
            return View(model);
        }
    }
}
