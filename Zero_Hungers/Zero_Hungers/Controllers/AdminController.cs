using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hungers.Auth;
using Zero_Hungers.EF;

namespace Zero_Hungers.Controllers
{
    public class AdminController : Controller
    {
        [ALogged]
        public ActionResult Index()
        {
            return View();
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
            var data = db.Admins.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (data != null)
            {
                int AdminID = data.AdminID;
                Session["AdminID"] = AdminID;

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View();
            }
        }

        [ALogged]
        public ActionResult ViewReq()
        {
            var db = new Zero_HungersEntities2();
            //var data = db.CRs.ToList();
            var data = db.CRs.Where(c=> c.Status == "Requesting").ToList();
            return View(data);
        }

        [ALogged]
        [HttpGet]
        public ActionResult AcceptRequest(int id)
        {
            var db = new Zero_HungersEntities2();
            var ExData = db.CRs.FirstOrDefault(n => n.CRID == id);
            return View(ExData);
        }
        
        [ALogged]
        [HttpPost]
        public ActionResult AcceptRequest(CR s)
        {
            var db = new Zero_HungersEntities2();
            var data = db.CRs.Find(s.CRID);
            data.Status = "Pending";
            data.EmployeeID = s.EmployeeID;
            db.SaveChanges();
            return RedirectToAction("ViewReq");
        }

    }
}