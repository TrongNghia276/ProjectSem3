using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sem3Project.Areas.Admin.Models;

using Sem3Project.Areas.Admin.Hubs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sem3Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Home")]
  
    public class HomeController : Controller
    {
        public string url = "https://clinicserviceswebapi20201222164153.azurewebsites.net/api/";
        private HttpClient httpClient = new HttpClient();
        public bool CheckLogin()
        {
            string Role = HttpContext.Session.GetString("_Role");
            if (string.IsNullOrEmpty(Role))
            {
                return false;

            }
            else
            {
                string _Role = Role.ToUpper();
                if (_Role.Equals("ADMIN")||_Role.Equals("EDITOR"))
                {
                    return true;
                }
                

            }
            return false;
        }
        [Route("index")]
        public IActionResult Index()
        {
            
            if (!CheckLogin()) return RedirectToAction("Login");
            return View();

        }

        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(string UserName, string PassWord)
        {

            var model = JsonConvert.DeserializeObject<IEnumerable<Accounts>>(httpClient.GetStringAsync(url + "Accounts/").Result);
            Accounts accounts = model.Where(e => e.AccountName.Equals(UserName)).FirstOrDefault();
            if (accounts != null)
            {
                if (accounts.Password.Equals(PassWord))
                {
                    HttpContext.Session.SetString("_UserName", UserName);
                    HttpContext.Session.SetString("_Image", accounts.Image);
                    HttpContext.Session.SetString("_Role", accounts.Role);
                    HttpContext.Session.SetInt32("_ID", accounts.AccountID);
                    HttpContext.Session.SetString("_FirstName", accounts.FirstName);
                    HttpContext.Session.SetString("_LastName", accounts.LastName);
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.Msg = "Password wrong!!!";
                }



            }
            return View();
        }
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [Route("RoomChat")]
        public IActionResult RoomChat()
        {
            return View();
        }
    }
}
