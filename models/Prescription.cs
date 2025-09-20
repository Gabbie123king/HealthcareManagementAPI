using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareManagementAPI.models
{
    public class Prescription
    {
        public Guid PrescriptionId { get; set; }
        public Guid PatientId { get; set; }
        public Patient? Patient { get; set; }
        public string? Medication { get; set; }
        public string? Dosage { get; set; }
        public DateTime PrescribedAt { get; set; } = DateTime.UtcNow;
    }
}