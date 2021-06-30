using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sem3Project.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Sem3Project.Controllers
{
    public class MedicinesController : Controller
    {
        private string url = "http://localhost:61505/api/Medicines/";
        private HttpClient httpClient = new HttpClient();
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var model = JsonConvert.DeserializeObject<Medicines>(httpClient.GetStringAsync(url + id).Result);
            return View(model);
        }
    }
}
