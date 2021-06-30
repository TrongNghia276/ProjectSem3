using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sem3Project.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sem3Project.Areas.Admin.Components
{
    [ViewComponent(Name = "Accounts")]
    public class AccountsViewComponents : ViewComponent
    {
        public string url = "https://clinicserviceswebapi20201222164153.azurewebsites.net/api/Accounts";
        private HttpClient httpClient = new HttpClient();



        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = JsonConvert.DeserializeObject<IEnumerable<Accounts>>(httpClient.GetStringAsync(url).Result);

            return View(model);
        }

    }
}
