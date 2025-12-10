using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.request;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF_Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>()
                .HasOne(r => r.RegustedUser)
                .WithMany()
                .HasForeignKey(p=>p.RegustedUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
