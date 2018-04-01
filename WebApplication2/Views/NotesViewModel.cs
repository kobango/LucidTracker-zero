using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public class NotesViewModel
    {
        public int Id { get; set; }
        public string Thema { get; set; }
        public string Text { get; set; }
    }

    public class NotesViewModelDBC : ApplicationDbContext
    {
        public DbSet<NotesViewModel> NotesViewModels { get; set; }
    }
}