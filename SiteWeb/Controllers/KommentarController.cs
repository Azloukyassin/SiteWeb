using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteWeb.Controllers
{
    public class KommentarController : Controller
    {
        // GET: Kommentar
        GhadaDBEntities4 _db;
        public KommentarController()
        {
            _db = new GhadaDBEntities4();
        }
        
        // GET: User
        public ActionResult Index()
        {
            var test = _db.Commentar.ToList();
            return View(test); 
        }
        // GET: User
        public ActionResult AddOrEdit(int id = 0)
        {
             Commentar userModel= new Commentar();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(Commentar userModel)
        {
            using (GhadaDBEntities4 model = new GhadaDBEntities4())
            {
                model.Commentar.Add(userModel);
                model.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Commentar Successful ";
            return View("AddOrEdit", new Commentar());
        }
    }
}