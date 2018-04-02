using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication2.Models;

namespace WebApplication2.Database
{
    public class LucidTrackerDbContext : IdentityDbContext<ApplicationUser>
    {
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