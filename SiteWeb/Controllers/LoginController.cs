using SiteWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserReg.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(User_Projet userModel)
        {
            using (GhadaDBEntities db = new GhadaDBEntities())
            {
                var userDetails = db.User_Projet.Where(x => x.email == userModel.email && x.password == userModel.password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = " Error!!";
                    return View("Index", userModel);
                }
                else
                    return View("~/Views/FirstLayout/ChoixIndex.cshtml", userModel);
            }
        }
    }
}