using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoListMVC.DAL;

namespace ToDoListMVC.Controllers
{
    public class ItemsController : Controller
    {
        private ToDoListEntitiesContext db = new ToDoListEntitiesContext();

        // GET: Items
        public ActionResult Index()
        {
            var items = db.Items.ToList();

            return View(items);
        }

        public ActionResult Details(int id)
        {
            var details = db.Items.FirstOrDefault(items => items.ItemId == id);

            return View(details);
        }
    }
}