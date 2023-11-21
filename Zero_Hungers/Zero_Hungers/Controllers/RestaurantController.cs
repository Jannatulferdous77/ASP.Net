using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Zero_Hungers.Auth;
using Zero_Hungers.EF;

namespace Zero_Hungers.Controllers
{
    public class RestaurantController : Controller
    {
        [RLogged]
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
            var data = db.Restaurants.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (data != null)
            {
                int restaurantID = data.RestaurantID;
                Session["RestaurantID"] = restaurantID;

                return RedirectToAction("Index");
            }
            else
            {
                // Handle invalid login credentials
                ModelState.AddModelError("", "Invalid email or password");
                return View();
            }
        }


        [RLogged]
        [HttpGet]
        public ActionResult CreateRequest()
        {
            return View();
        }

        [RLogged]
        [HttpPost]
        public ActionResult CreateRequest(string iteam, string creationTime, string expireTime)
        {
            int RestaurantID = (int)Session["RestaurantID"];
            var db = new Zero_HungersEntities2();

            var cr = new CR
            {
                Iteam = iteam,
                CreationTime = DateTime.Now.ToString(),
                ExpireTime = expireTime,
                RestaurantID = RestaurantID,
                Status = "Requesting"
            };

            db.CRs.Add(cr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [RLogged]
        public ActionResult History()
        {
            int RestaurantID = (int)Session["RestaurantID"];
            var db = new Zero_HungersEntities2();
            var data = db.CRs.Where(c => c.Status == "Accepted" && c.RestaurantID == RestaurantID).ToList();
            return View(data);
        }

    }
}