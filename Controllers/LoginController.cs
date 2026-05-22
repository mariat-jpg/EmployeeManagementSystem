using Microsoft.AspNetCore.Mvc;
using Employee.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace Employee.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult SignIn()
        {
            Employee.Models.Login login = new Employee.Models.Login();
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(Employee.Models.Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            Employee.Models.Login_DAL log = new Employee.Models.Login_DAL();
            bool isValid = log.Check(login.username, login.password);

            if (isValid)
            {
                string Type = log.Verify(login.username, login.password);

                if (login.username == "ADMIN" && login.password == "AdminPass123!" && Type == "admin")
                {
                    return RedirectToAction("Index", "Emp");
                }
                else
                {
                    return RedirectToAction("User_Index", "Emp");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(login);
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Employee.Models.Register reg)
        {
            if (!ModelState.IsValid)
            {
                return View(reg);
            }
            else
            {
                try
                {
                    Employee.Models.Login_DAL created = new Employee.Models.Login_DAL();
                    created.Create_User(reg);
                    return RedirectToAction("SignIn");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("",ex.Message);
                    return View(reg);
                }
            }
        }
    }
}
