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
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        private DateTime? _dateOfBirth;
        public DateTime? DateOfBirth
        {
            get => _dateOfBirth;
            set => _dateOfBirth = value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : null;
        }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<MedicalRecord>? MedicalRecords { get; set; }
        public ICollection<Prescription>? Prescriptions { get; set; }
    }
}