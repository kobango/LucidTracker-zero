using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Database;
using WebApplication2.Models;
using WebApplication2.ViewModels;
using WebApplication2.Controllers;

namespace WebApplication2.Models
{
    public class NotesManager : Controller
    {
        private LucidTrackerDbContext db;

        public NotesManager(LucidTrackerDbContext db)
        {
            this.db = db;
        }

        public List<NotesViewModel> GetAllNotes()
        {
            return db.Notes.ToList();
        }

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

        public ActionResult Delete(int? id)
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

        public ActionResult DeleteConfirmed(int id)
        {
            NotesViewModel notesViewModel = db.Notes.Find(id);
            db.Notes.Remove(notesViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create([Bind(Include = "Id,Thema,Text")] NotesViewModel notesViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Notes.Add(notesViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notesViewModel);
        }

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

        public  void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}