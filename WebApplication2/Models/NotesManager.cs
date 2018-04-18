using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Database;
using WebApplication2.ViewModels;

namespace WebApplication2.Models
{
    public class NotesManager
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
    }
}