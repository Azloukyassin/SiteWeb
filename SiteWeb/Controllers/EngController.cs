using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SiteWeb.Controllers
{
    public class EngController : Controller
    {
        GhadaDBEntities _db;
        public EngController()
        {
            _db = new GhadaDBEntities();
        }
        public ActionResult List()
        {
            var test = _db.User_Projet.ToList();
            return View(test);
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        // GET: User
        public ActionResult AddOrEdit(int id = 0)
        {
           User_Projet userModel = new User_Projet();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(User_Projet userModel)
        {
            using (GhadaDBEntities model = new GhadaDBEntities())
            {
                model.User_Projet.Add(userModel);
                model.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful ";
            return View("AddOrEdit", new User_Projet());
        }

        
    }
}