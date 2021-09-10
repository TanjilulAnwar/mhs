using MHS.Models;
using MHS.Models.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace MHS.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
      

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
   
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        
        public DbSet<IPInfo> ip_info { get; set; }
 


    }
}
