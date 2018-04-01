using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Database;

namespace WebApplication2.Controllers
{
    public class NotesViewModelsController : Controller
    {
        private NotesViewModelDBC db = new NotesViewModelDBC();

        // GET: NotesViewModels
        public ActionResult Index()
        {
            return View(db.NotesViewModels.ToList());
        }

        // GET: NotesViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotesViewModel notesViewModel = db.NotesViewModels.Find(id);
            if (notesViewModel == null)
            {
                return HttpNotFound();
            }
            return View(notesViewModel);
        }

        // GET: NotesViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotesViewModels/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Thema,Text")] NotesViewModel notesViewModel)
        {
            if (ModelState.IsValid)
            {
                db.NotesViewModels.Add(notesViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notesViewModel);
        }

        // GET: NotesViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotesViewModel notesViewModel = db.NotesViewModels.Find(id);
            if (notesViewModel == null)
            {
                return HttpNotFound();
            }
            return View(notesViewModel);
        }

        // POST: NotesViewModels/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Thema,Text")] NotesViewModel notesViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notesViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notesViewModel);
        }

        // GET: NotesViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotesViewModel notesViewModel = db.NotesViewModels.Find(id);
            if (notesViewModel == null)
            {
                return HttpNotFound();
            }
            return View(notesViewModel);
        }

        // POST: NotesViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NotesViewModel notesViewModel = db.NotesViewModels.Find(id);
            db.NotesViewModels.Remove(notesViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}
