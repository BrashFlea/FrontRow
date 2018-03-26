using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FrontRowCMS2.Models;
using FrontRowCMS2.Models.Home;
using FrontRowCMS2.Models.Secondary;

namespace FrontRowCMS2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Site-wide DbSet
        public DbSet<User> User { get; set; }
        public DbSet<Footer> Footer { get; set; }

        //DbSet for Home Page
        public DbSet<Header> Header { get; set; }
        public DbSet<Models.Home.Services> Services { get; set; }
        public DbSet<Purpose> Purpose { get; set; }

        //DbSet for Secondary Page
        public DbSet<History> History { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Outreach> Outreach { get; set; }
        public DbSet<OutreachTable> OutreachTable { get; set; }
        public DbSet<Needs> Needs { get; set; }
        public DbSet<Calendar> Calendar { get; set; }
        public DbSet<CalendarMonths> CalendarMonths { get; set; }
        public DbSet<CalendarEvents> CalendarEvents { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
