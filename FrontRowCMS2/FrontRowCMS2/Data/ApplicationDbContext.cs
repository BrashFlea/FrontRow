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
        public DbSet<Footer> Footer { get; set; }

        //DbSet for Home Page
        public DbSet<Header> Header { get; set; }
        public DbSet<Models.Home.Services> Services { get; set; }
        public DbSet<LinkSubContent> LinkSubContent { get; set; }
        public DbSet<Purpose> Purpose { get; set; }
        public DbSet<BottomHomePage> BottomHomePage { get; set; }

        //DbSet for Secondary Page
        public DbSet<SecondaryHeader> SecondaryHeader { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<Outreach> Outreach { get; set; }
        public DbSet<Needs> Needs { get; set; }
        public DbSet<Calendar> Calendar { get; set; }
        public DbSet<CalendarMonths> CalendarMonths { get; set; }
        public DbSet<CalendarEvents> CalendarEvents { get; set; }
        public DbSet<MediaEvent> MediaEvent { get; set; }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<Donate> Donate { get; set; }
        public DbSet<TextSubContent> TextSubContent { get; set; }
        public DbSet<SecondaryPage> SecondaryPage { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
