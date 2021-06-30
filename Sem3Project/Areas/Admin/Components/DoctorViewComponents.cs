using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sem3Project.Areas.Admin.Models;
namespace Sem3Project.Areas.Admin.Components
{
    [ViewComponent(Name = "Doctor")]
    public class DoctorViewComponent : ViewComponent
    {
        public string url = "https://clinicserviceswebapi20201222164153.azurewebsites.net/api/Accounts";
        private HttpClient httpClient = new HttpClient();



        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = JsonConvert.DeserializeObject<IEnumerable<Accounts>>(httpClient.GetStringAsync(url).Result);

            var acc = from s in model
                      select s;
            acc = acc.Where(a => a.Role.ToString().Equals("Doctor"));
            return View(acc);
        }

    }
}
