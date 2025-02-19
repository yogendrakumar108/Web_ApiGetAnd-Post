using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Web_Api.Models;


namespace Web_Api.Controllers
{
    
    public class HomeController : Controller
    {
        AdoDbEntities db = new AdoDbEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        [HttpGet]
        public ActionResult GetVal(string name)
        {
            var res= db.Employees.Where(x=> x.EmpName==name).First();
            if(res != null) 
            { 
               var data=db.Employees.ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("res is null", JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        public ActionResult PostVal(Employee res) 
        {
            var Data = db.Employees.ToList();
            if (res !=null)
            {
                db.Employees.Add(res);
                db.SaveChanges();
                
                  return Json("Succeessfully data Added", JsonRequestBehavior.AllowGet);
                
                
            }
            else
            {
                return Json("fill All data", JsonRequestBehavior.AllowGet);
            }
        }

    }
}
