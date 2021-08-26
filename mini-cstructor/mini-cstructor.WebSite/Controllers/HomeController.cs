using Microsoft.AspNetCore.Mvc;
using mini_cstructor.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using mini_cstructor.Business;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace mini_cstructor.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClassManager classManager;
        private readonly IUserManager userManager;
        public HomeController(IClassManager classManager, IUserManager userManager)
        {
            this.classManager = classManager;
            this.userManager = userManager;
        }

        public ActionResult Index()
        {
            var model = new IndexModel { };
            return View(model);
        }

        public ActionResult ClassList()
        {
            var classes = classManager.Classes
                                            .Select(t => new mini_cstructor.WebSite.Models.ClassModel(t.ClassId, t.ClassName, t.ClassDescription, t.ClassPrice))
                                            .ToArray();
            var model = new ClassesModel { Classes = classes };
            return View(model);
        }

        public ActionResult LogIn()
        {
            ViewData["ReturnUrl"] = Request.Query["returnUrl"];
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.LogIn(loginModel.UserName, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "User name and password do not match.");
                }
                else
                {
                    var json = JsonConvert.SerializeObject(new mini_cstructor.WebSite.Models.UserModel
                    {
                        Id = user.Id,
                        Name = user.Name
                    });

                    HttpContext.Session.SetString("User", json);

                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, "User"),
                };

                    var claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = false,
                        // Refreshing the authentication session should be allowed.

                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        IsPersistent = false,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        IssuedUtc = DateTimeOffset.UtcNow,
                        // The time at which the authentication ticket was issued.
                    };

                    HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        claimsPrincipal,
                        authProperties).Wait();

                    return Redirect(returnUrl ?? "~/");
                }
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View(loginModel);
        }

        public ActionResult LogOff()
        {
            HttpContext.Session.Remove("User");

            HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("~/");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Register(registerModel.UserName, registerModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("msg", "The email is already in use.");
                    return View();
                }


                return Redirect("~/");
            }

            return View();
        }

        public IActionResult AddClass()
        {
            var classes = classManager.Classes
                                            .Select(t => new mini_cstructor.WebSite.Models.ClassModel(t.ClassId, t.ClassName, t.ClassDescription, t.ClassPrice))
                                            .ToArray();

            var model = new ClassesModel { Classes = classes };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddClass(WebSite.Models.ClassModel classModel)
        {
            if (ModelState.IsValid)
            {
                var sessionUser = HttpContext.Session.GetString("User");

                if (sessionUser != null)
                {
                    var user = JsonConvert.DeserializeObject<WebSite.Models.UserModel>(sessionUser);
                    Business.UserClassModel newUserClass = userManager.AddClass(user.Id, classModel.ClassId);

                    if (newUserClass == null)
                    {
                        RedirectToAction("AddClass");
                    }
                }
            }

            return RedirectToAction("StudentClasses");
        }

        public IActionResult StudentClasses()
        {
            var sessionUser = HttpContext.Session.GetString("User");
            var studentclasses = Array.Empty<Business.ClassModel>();

            if (sessionUser != null)
            {
                var user = JsonConvert.DeserializeObject<WebSite.Models.UserModel>(sessionUser);
                studentclasses = userManager.EnrolledClasses(user.Id);
            }

            var model = new ClassesModel { Classes = Array.ConvertAll(studentclasses, t => new WebSite.Models.ClassModel(t.ClassId, t.ClassName, t.ClassDescription, t.ClassPrice)) };
            return View(model);
        }



        public IActionResult About()
        {
            ViewData["Message"] = "The best learning site on the internet";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "We are here to serve you";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
