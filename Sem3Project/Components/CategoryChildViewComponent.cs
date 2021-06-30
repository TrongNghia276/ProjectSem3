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
    public class CategoryChildViewComponent : ViewComponent
    {
        public string url = "http://localhost:61505/api/CategoryChilds/";
        private HttpClient httpClient = new HttpClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<CategoryChild>>(httpClient.GetStringAsync(url).Result);
            var acc = from s in model
                      where s.CategoriesID == 202
                      select s;
            //var acc = acc.Where(p => p.CategoriesID == 202).ToList();
            return View(acc);
        }
    }
}
