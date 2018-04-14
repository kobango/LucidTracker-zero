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
using Microsoft.AspNet.Identity;

namespace WebApplication2.Controllers
{
    public class NotesController : Controller
    {
        private LucidTrackerDbContext db = new LucidTrackerDbContext();

        // GET: NotesViewModels
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return View(db.Notes.ToList().Where(x => x.UserID == new Guid(User.Identity.GetUserId())));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: NotesViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotesViewModel notesViewModel = db.Notes.Find(id);
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
                notesViewModel.UserID = new Guid(User.Identity.GetUserId());
                db.Notes.Add(notesViewModel);
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
            NotesViewModel notesViewModel = db.Notes.Find(id);
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
            notesViewModel.UserID = new Guid(User.Identity.GetUserId());
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
            NotesViewModel notesViewModel = db.Notes.Find(id);
            notesViewModel.UserID = new Guid(User.Identity.GetUserId());
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
            NotesViewModel notesViewModel = db.Notes.Find(id);
            notesViewModel.UserID = new Guid(User.Identity.GetUserId());
            db.Notes.Remove(notesViewModel);
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
