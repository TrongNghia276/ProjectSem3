using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Sem3Project.Models;

namespace Sem3Project.Components
{
    public class MedicalEquipmentsViewComponent : ViewComponent
    {
        private string url = "http://localhost:61505/api/MedicalEquipments/";
        private HttpClient httpClient = new HttpClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var items = context.MedicalEquipments.ToList();
            var items = JsonConvert.DeserializeObject<IEnumerable<MedicalEquipments>>(httpClient.GetStringAsync(url).Result);
            return View(items);
        }
    }
}
