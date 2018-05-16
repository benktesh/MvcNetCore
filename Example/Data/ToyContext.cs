using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Example.Models;
using Example.ViewModel;

namespace Example.Data
{
    public interface IAppDbContext
    {
        DbSet<DataProcessor> DataProcessors { get; set; }
        DbSet<DPSystem> DPSystems { get; set; }
        DbSet<SystemCapablity> SystemCapablities { get; set; }
        DbSet<SystemCode> SystemCodes { get; set; }

        DbSet<Contact> Contacts { get; set; }
        DbSet<SystemService> SystemServices { get; set; }

        

        Task SaveChangesAsync();
        void Entry(DataProcessor existing);
    }
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<DataProcessor> DataProcessors { get; set; }
        public DbSet<DPSystem> DPSystems { get; set; }
        public DbSet<SystemCapablity> SystemCapablities { get; set; }
        public DbSet<SystemCode> SystemCodes { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SystemService> SystemServices { get;set; }
        //public Task SaveChangesAsync()
        //{
        //   return base.SaveChangesAsync();
        //}

        //public void Entry(DataProcessor existing)
        //{
        //    base.Entry(existing);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //if names are different than model we can map it here
            modelBuilder.Entity<DataProcessor>().ToTable("DataProcessor");  
            modelBuilder.Entity<DPSystem>().ToTable("DPSystem");
            modelBuilder.Entity<SystemCapablity>().ToTable("SystemCapablity");
            modelBuilder.Entity<SystemCode>().ToTable("SystemCode");
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<SystemService>().ToTable("SystemService");

            //Enforece Constratins
            modelBuilder.Entity<Contact>()
                .HasOne(p => p.DataProcessor)
                .WithMany(p => p.Contacts)
                .OnDelete(DeleteBehavior.Cascade);

        }
      
    }
}
