using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonelProject.ToDo.DataAccess.Concrete.EFC.Mapping;
using PersonelProject.ToDo.Entities.Concrete;

namespace PersonelProject.ToDo.DataAccess.Concrete.EFC.Contexts
{
    public class ToDoContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=İsTakip; user id=sa; password=1");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new MissionMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new UrgencyMap());


            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Report> Reports  { get; set; }
        public DbSet<Urgency> Urgencies { get; set; }
    }
}
