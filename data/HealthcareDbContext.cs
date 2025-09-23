using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthcareManagementAPI.models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManagementAPI.data
{
    public class HealthcareDbContext : DbContext
    {
        public HealthcareDbContext(DbContextOptions<HealthcareDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasIndex(a => new { a.DoctorId, a.StartTime, a.EndTime })
                .IsUnique();

            modelBuilder.Entity<Patient>()
                .HasIndex(p => p.Email)
                .IsUnique();

            
        }
    }
}