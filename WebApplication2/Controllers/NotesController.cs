using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication2.Database;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class NotesController : Controller
    {
        private LucidTrackerDbContext db;//to pojdzie do usuniecia
        private NotesManager manager = new NotesManager(new LucidTrackerDbContext());

        //konstruktor też będzie do usunięcia 
        public NotesController(LucidTrackerDbContext db)
        {
            this.db = db;
        }

        // GET: NotesViewModels
        public ActionResult Index()
        {
            return View(manager.GetAllNotes());
        }

        // GET: NotesViewModels/Details/5
        public ActionResult Details(int? id)
        {
            return manager.Details(id);
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
            return manager.Create(notesViewModel);
        }

        // GET: NotesViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            return manager.Edit(id);
        }

        // POST: NotesViewModels/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Thema,Text")] NotesViewModel notesViewModel)
        {
            return manager.Edit(notesViewModel);
        }

        // GET: NotesViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            return manager.Delete(id);
        }

        // POST: NotesViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return manager.DeleteConfirmed(id);
        }

        protected override void Dispose(bool disposing)
        {
            manager.Dispose();
        }


    }
}
