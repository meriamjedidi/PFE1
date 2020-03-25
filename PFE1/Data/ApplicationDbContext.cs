using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PFE1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PFE1.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {
        }
        public DbSet<Personnel> Personnel { get; set; }

       

        public DbSet<RegisterViewModel> Registre { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            #region "Seed Data"
            builder.Entity<IdentityRole>().HasData(
                new { /* Id = "1", Name = "Personnel", NormalizedName = "Personnel"*/
                    Id=1,
                    Username= "meriam",
                    Password="meriam123"
                }
                
                


                );
            #endregion
        }

    }

}
