using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ozpa.Controllers
{
    public class Login : Controller
    {
        Context c = new Context();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        } 
        public async Task<IActionResult> Index(AdminLogin p)
        {
            var bilgiler = c.AdminLogins.FirstOrDefault(x => x.LoginName == p.LoginName && x.LoginPassword == p.LoginPassword);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.LoginName)
                };
                var useridentity = new ClaimsIdentity(claims, "AdminLogin");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("ABrand", "AdminBrand");
            }
            return View();
        }
    }
}
