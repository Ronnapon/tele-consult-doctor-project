using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tele_consult.Data.Models;

namespace tele_consult.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many to Many
            modelBuilder.Entity<Doctor_Specialization>()
                .HasOne(b => b.Doctor)
                .WithMany(ba => ba.Doctor_Specialization)
                .HasForeignKey(bi => bi.DoctorId);

            modelBuilder.Entity<Doctor_Specialization>()
               .HasOne(b => b.Specialization)
               .WithMany(ba => ba.Doctor_Specialization)
               .HasForeignKey(bi => bi.SpecializationId);
        }


        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor_Specialization> Doctor_Specialization { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<Login> Users { get; set; }
    }
}
