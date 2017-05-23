using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var edit = db.Items.FirstOrDefault(items => items.ItemId == id);

            return View(edit);
        }

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}