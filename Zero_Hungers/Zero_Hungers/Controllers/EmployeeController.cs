using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hungers.Auth;
using Zero_Hungers.EF;

namespace Zero_Hungers.Controllers
{
    public class EmployeeController : Controller
    {
        [ELogged]
        public ActionResult Index()
        {
            int EmployeeID = (int)Session["EmployeeID"];
            var db = new Zero_HungersEntities2();
            var data = db.CRs.Where(e => e.EmployeeID == EmployeeID && e.Status != "Accepted").ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var db = new Zero_HungersEntities2();
            var data = db.Employees.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (data != null)
            {
                int EmployeeID = data.EmployeeID;
                Session["EmployeeID"] = EmployeeID;

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View();
            }
        }

        [ELogged]
        [HttpGet]
        public ActionResult AcceptRequest(int id)
        {
            var db = new Zero_HungersEntities2();
            var ExData = db.CRs.FirstOrDefault(n => n.CRID == id);
            return View(ExData);
        }

        [ELogged]
        [HttpPost]
        public ActionResult AcceptRequest(CR s)
        {
            var db = new Zero_HungersEntities2();
            var exData = db.CRs.Find(s.CRID);
            exData.Status = "Accepted";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ELogged]
        public ActionResult AcceptedRequest(CR s)
        {
            int EmployeeID = (int)Session["EmployeeID"];
            var db = new Zero_HungersEntities2();
            var data = db.CRs.Where(e => e.EmployeeID == EmployeeID && e.Status == "Accepted").ToList();
            db.SaveChanges();
            return View(data);
        }

    }
}