using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthcareManagementAPI.models;

namespace HealthcareManagementAPI.models
{
    public class Patient
    {
        public Guid PatientId { get; set; }
        public string? FirsName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<MedicalRecord>? MedicalRecords { get; set; }
        public ICollection<Prescription>? Prescriptions { get; set; }
    }
}