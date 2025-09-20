using System;
using HealthcareManagementAPI.models;

namespace HealthcareManagementAPI.models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Patient? Patient { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Status { get; set; } // Scheduled, Completed, Cancelled
    }
}
