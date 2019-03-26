using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DataBaseManager dbm = new DataBaseManager(Properties.Settings.Default.constr);
            IEnumerable<Person>people = dbm.GetAllPeople();
            return View(people);
        }
      
       public ActionResult AddPeople()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(List<Person> people)
        {
            DataBaseManager dbm = new DataBaseManager(Properties.Settings.Default.constr);
            dbm.AddPeople(people);
            return Redirect("/home/Index");
        }

       
    }
}