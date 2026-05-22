using Employee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Employee.Controllers
{
    public class EmpController : Controller
    {
        public ActionResult Index()
        {
            Models.Emp_DAL emp = new Models.Emp_DAL();
            return View(emp.Get_Details());
        }
        public ActionResult User_Index()
        {
            Models.Emp_DAL emp = new Models.Emp_DAL();
            return View(emp.Get_Details());
        }
        public ActionResult Details(int id)
        {
            Employee.Models.Emp_DAL empl = new Employee.Models.Emp_DAL();
            return View(empl.Get_Emp(id));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee.Models.Emp_Data emp)
        {
            try
            {
                Employee.Models.Emp_DAL created = new Employee.Models.Emp_DAL();
                created.Create_Emp(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            Employee.Models.Emp_DAL emp = new Employee.Models.Emp_DAL();
            return View(emp.Get_Emp(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Employee.Models.Emp_Data emp)
        {
            try
            {
                Employee.Models.Emp_DAL emp1 = new Employee.Models.Emp_DAL();
                emp1.Update_Emp(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            Employee.Models.Emp_DAL emp = new Employee.Models.Emp_DAL();
            Employee.Models.Emp_Data empdel = emp.Get_Emp(id);
            return View(empdel);
        }

        [HttpPost]
        public ActionResult Delete(int id, Employee.Models.Emp_Data emp)
        {
            try
            {
                Employee.Models.Emp_DAL emp1 = new Employee.Models.Emp_DAL();
                emp1.Delete_Emp(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
