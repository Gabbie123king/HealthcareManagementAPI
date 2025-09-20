using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareManagementAPI.models
{
    public class MedicalRecord
    {
        public Guid MedicalRecordId { get; set; }
        public Guid PatientId { get; set; }
        public Patient? Patient { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}