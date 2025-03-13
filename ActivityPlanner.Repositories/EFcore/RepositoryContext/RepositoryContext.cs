using ActivityPlanner.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Repositories.EFcore.RepositoryContext
{
    public class RepositoryContext : IdentityDbContext<AppUser>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<ShortLink> ShortLink {  get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


    }
}
