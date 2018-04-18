using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
    public class NotesViewModel
    {
        public int Id { get; set; }
        public string Thema { get; set; }
        public string Text { get; set; }
        public Guid UserID { get; set; }
    }
}