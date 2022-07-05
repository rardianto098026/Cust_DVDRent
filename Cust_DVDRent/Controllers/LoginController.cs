using Cust_DVDRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Cust_DVDRent.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            LoginModels model = new LoginModels();
            return View(model);
        }
        public ActionResult Signup()
        {
            SignupModels model = new SignupModels();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LoginModels model)
        {
            using (var client = new HttpClient())
            {
                model.role = 2;
                client.BaseAddress = new Uri("http://localhost:26403/api/Users/toLogin");
                var postJob = client.PostAsJsonAsync<LoginModels>("toLogin", model);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    return RedirectToAction("../HomeDVD/index");
                }
                model.status = "failed";

                ModelState.AddModelError(string.Empty, "Server occured errors. Please check with admin!");
            }
            return View(model);
        }

        public ActionResult Search(LoginModels model)
        {

            return View(model);
        }

        [HttpPost]
        public ActionResult Signup(SignupModels model)
        {
            if(model.password != model.confirmpassword)
            {
                model.erormsg = "Password tidak sama!";
                model.status = "failed";
                return View(model);
            }else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:26403/api/Users/Register");
                    var postJob = client.PostAsJsonAsync<SignupModels>("Register", model);
                    postJob.Wait();

                    var postResult = postJob.Result;
                    if (postResult.IsSuccessStatusCode)
                    {
                        return RedirectToAction("../HomeDVD/index");
                    }else if(postResult.StatusCode == System.Net.HttpStatusCode.Found)
                    {
                        model.status = "email";
                        model.erormsg = "email telah digunakan";
                        return View(model);
                    }
                    model.status = "failed";
                    model.erormsg = "error";
                    ModelState.AddModelError(string.Empty, "Server occured errors. Please check with admin!");
                }
            }
            return View(model);
        }
    }
}