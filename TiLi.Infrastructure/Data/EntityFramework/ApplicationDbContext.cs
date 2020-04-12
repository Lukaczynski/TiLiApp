using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TiLi.Infrastructure.Data.Entities;
using TiLi.Infrastructure.Data.EntityFramework.Entities;


namespace TiLi.Infrastructure.Data.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<AppUserProject> AppUserProjects { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<AppRole>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            #region Relations
            modelBuilder.Entity<AppUserProject>()
                .HasKey(bc => new { bc.AppUserId, bc.ProjectId });
            modelBuilder.Entity<AppUserProject>()
                .HasOne(bc => bc.Project)
                .WithMany(b => b.AppUserProject)
                .HasForeignKey(bc => bc.ProjectId);
            modelBuilder.Entity<AppUserProject>()
                .HasOne(bc => bc.AppUser)
                .WithMany(c => c.AppUserProject)
                .HasForeignKey(bc => bc.AppUserId);
            modelBuilder.Entity<Project>()
                .HasMany(b => b.TimeEntries)
                ;
            #endregion Relations



        }

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }

        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
                ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}
