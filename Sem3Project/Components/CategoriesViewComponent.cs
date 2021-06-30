using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sem3Project.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sem3Project.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        public string url = "http://localhost:61505/api/Categories/";
        private HttpClient httpClient = new HttpClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<Sem3Project.Models.Categories>>(httpClient.GetStringAsync(url).Result);
            return View(model);
        }
    }
}
