using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Sem3Project.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sem3Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Account")]
    public class AccountController : Controller
    {

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
                if (_Role.Equals("ADMIN") || _Role.Equals("EDITOR"))
                {
                    return true;
                }

            }
            return false;
        }
        private string url = "https://clinicserviceswebapi20201222164153.azurewebsites.net/api/Accounts";
        private HttpClient httpClient = new HttpClient();
        [Route("Show")]
        public IActionResult Show()
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Home");

            return View();
        }
        [Route("Lock")]
        [HttpGet]
        public IActionResult Lock(int id)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Home");
            var model = JsonConvert.DeserializeObject<Accounts>(httpClient.GetStringAsync(url + id).Result);


            return View(model);
        }
        [Route("Lock")]
        [HttpPost]
        public IActionResult Lock([Bind("AccountHistory,AccountID,AccountName,Active,CheckPassword,AccountLock,City,Country,District,DoB,Email,FirstName,Image,LastName,Password,Phone,Role,State,Street,Zipcode")] Accounts acc)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Home");
            acc.AccountLock = true;
            var model = httpClient.PutAsJsonAsync<Accounts>(url, acc).Result;
            
            if (model.IsSuccessStatusCode)
            {
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_Show", acc) });
            }
            else
            {
                ViewBag.Msg = "Fail";
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Lock", acc) });
        }
        [Route("Unlock")]
        [HttpGet]
        public IActionResult Unlock(int id)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Home");
            var model = JsonConvert.DeserializeObject<Accounts>(httpClient.GetStringAsync(url + id).Result);


            return View(model);
        }
        [Route("Unlock")]
        [HttpPost]
        public IActionResult Unlock([Bind("AccountHistory,AccountID,AccountName,Active,CheckPassword,AccountLock,City,Country,District,DoB,Email,FirstName,Image,LastName,Password,Phone,Role,State,Street,Zipcode")] Accounts acc)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Home");
            acc.AccountLock = false;
            var model = httpClient.PutAsJsonAsync<Accounts>(url, acc).Result;
            if (model.IsSuccessStatusCode)
            {
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_Show", acc) });
            }
            else
            {
                ViewBag.Msg = "Fail";
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "UnLock", acc) });
        }
        [Route("Doctor")]
        public IActionResult Doctor()
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Home");

            return View();
        }
        [Route("Profile")]
        public IActionResult Profile()
        {
            string _ID = HttpContext.Session.GetInt32("_ID").ToString();
            if (!CheckLogin()) return RedirectToAction("Login", "Home");
            var model = JsonConvert.DeserializeObject<IEnumerable<Accounts>>(httpClient.GetStringAsync(url).Result);
            var acc = from s in model
                      select s;
            acc = acc.Where(a => a.AccountID.ToString().Equals(_ID));
            return View(acc);
        }
        [Route("View")]
        public IActionResult View(int id)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Home");
            var model = JsonConvert.DeserializeObject<IEnumerable<Accounts>>(httpClient.GetStringAsync(url).Result);
            var acc = model.Where(a => a.AccountID==id);
            return View(acc);
        }
        [Route("Create")]
        [HttpGet]
        public IActionResult Create()
        {
            string Role = HttpContext.Session.GetString("_Role");
            if (!CheckLogin()) return RedirectToAction("Login", "Home");
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Text = "Customer",
                Value = "Customer"
            });
            items.Add(new SelectListItem
            {
                Text = "Doctor",
                Value = "Doctor"
            });
            string _Role = Role.ToUpper();
            if (_Role.Equals("ADMIN"))
            {
                items.Add(new SelectListItem
                {
                    Text = "Editor",
                    Value = "Editor"
                });
            }

            ViewBag.DDLItems = items;

            return View();
        }
        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Accounts account, IFormFile file)
        {
            try
            {
                Random rnd = new Random();
                int RandomName = rnd.Next(123456778, 987654321);
                int RandomName2 = rnd.Next(999999999);
                if (account.CheckPassword == account.Password)
                {
                    if (file != null)
                    {
                        account.Active = true;
                        string NameImage = RandomName.ToString() + RandomName2.ToString() + file.FileName;
                        var filePath = Path.Combine("wwwroot/Image/Acc_Avatar", NameImage);
                        var stream = new FileStream(filePath, FileMode.Create);
                        file.CopyToAsync(stream);
                        account.Image = NameImage;

                        var model = httpClient.PostAsJsonAsync<Accounts>(url, account).Result;
                        if (model.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Profile");
                        }
                        else
                        {
                            ViewBag.Msg = "Fail";
                        }

                    }
                    else
                    {
                        account.Active = true;
                        account.Image = "avatar.png";

                        var model = httpClient.PostAsJsonAsync<Accounts>(url, account).Result;
                        if (model.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Show");
                        }
                        else
                        {
                            ViewBag.Msg = "Fail";
                        }
                    }
                }
                else
                {
                    ViewBag.Msg = "Comfirm Password do not match";
                }


            }
            catch (Exception x)
            {

                ViewBag.Msg = x.Message;
            }


            return View();
        }
        [Route("Edit")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Home");
            var model = JsonConvert.DeserializeObject<Accounts>(httpClient.GetStringAsync(url + id).Result);

            return View(model);
        }
        [Route("Edit")]
        [HttpPost]
        public IActionResult Edit(Accounts account, IFormFile file)
        {

            Random rnd = new Random();
            int RandomName = rnd.Next(123456778, 987654321);
            int RandomName2 = rnd.Next(999999999);

            string aid;
            aid = HttpContext.Session.GetInt32("_ID").ToString();
            if(aid.Equals(account.AccountID.ToString())) { 
            if (file != null)
            {
                string NameImage = RandomName.ToString() + RandomName2.ToString() + file.FileName;
                var filePath = Path.Combine("wwwroot/Image/Acc_Avatar", NameImage);
                var stream = new FileStream(filePath, FileMode.Create);
                file.CopyToAsync(stream);
                //account.Photo = file.FileName;
                account.Image = NameImage;

                var model = httpClient.PutAsJsonAsync<Accounts>(url, account).Result;
                if (model.IsSuccessStatusCode)
                {
                    HttpContext.Session.SetString("_FirstName", account.FirstName);
                    HttpContext.Session.SetString("_LastName", account.LastName);
                    HttpContext.Session.SetString("_Image", account.Image);
                    return RedirectToAction("Profile");
                }
                else
                {
                    ViewBag.Msg = "Fail";
                }

            }
            else
            {
                var model = httpClient.PutAsJsonAsync<Accounts>(url, account).Result;
                if (model.IsSuccessStatusCode)
                {
                    HttpContext.Session.SetString("_FirstName", account.FirstName);
                    HttpContext.Session.SetString("_LastName", account.LastName);
                    return RedirectToAction("Profile");
                }
                else
                {
                    ViewBag.Msg = "Fail";
                }
            }
            }
            else
            {
                if (file != null)
                {
                    string NameImage = RandomName.ToString() + RandomName2.ToString() + file.FileName;
                    var filePath = Path.Combine("wwwroot/Image/Acc_Avatar", NameImage);
                    var stream = new FileStream(filePath, FileMode.Create);
                    file.CopyToAsync(stream);
                    //account.Photo = file.FileName;
                    account.Image = NameImage;

                    var model = httpClient.PutAsJsonAsync<Accounts>(url, account).Result;
                    if (model.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Show");
                    }
                    else
                    {
                        ViewBag.Msg = "Fail";
                    }

                }
                else
                {
                    var model = httpClient.PutAsJsonAsync<Accounts>(url, account).Result;
                    if (model.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Show");
                    }
                    else
                    {
                        ViewBag.Msg = "Fail";
                    }
                }
            }
            return View();
        }
       
    }
}
