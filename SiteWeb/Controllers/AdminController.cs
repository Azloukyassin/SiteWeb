using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteWeb.Controllers
{
    public class AdminController : Controller
    {


        // GET: Admin
        GhadaDBEntities4 _db;
        GhadaDBEntities5 _db1;
        public AdminController()
        {
            _db = new GhadaDBEntities4();
        }

        // GET: Admin
        public ActionResult Index()
        {
            var test = _db.Commentar.ToList();
            return View(test);
        }

        public ActionResult Indexx()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(Admin userModel)
        {
            using (GhadaDBEntities5 db = new GhadaDBEntities5())
            {
                var userDetails = db.Admin.Where(x => x.FirstName_Prof == userModel.FirstName_Prof && x.password == userModel.password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = " Error!!";
                    return View("Index", userModel);
                }
                else
                    return View("~/Views/FirstLayout/Index.cshtml", userModel);
            }
        }
    }
}