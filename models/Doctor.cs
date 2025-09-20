using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareManagementAPI.models
{
    public class Doctor
    {
        public Guid DoctorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Specialty { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}