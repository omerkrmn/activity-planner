using ActivityPlanner.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Repositories.EFcore.Config
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder
                .Property(a => a.CreatedAt)
                .HasDefaultValueSql("getdate()");

            builder
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Activities)
                .HasForeignKey(p => p.AppUserId);
        }
    }
}
