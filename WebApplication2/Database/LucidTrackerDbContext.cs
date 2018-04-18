using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication2.Models;
using WebApplication2;
using System.Data.Entity;
using WebApplication2.ViewModels;

namespace WebApplication2.Database
{
    public class LucidTrackerDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<NotesViewModel> Notes { get; set; }

        public LucidTrackerDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {


        }

        public static LucidTrackerDbContext Create()
        {
            return new LucidTrackerDbContext();
        }
    }

    
    

}