using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthcareManagementAPI.Dtos.Patient;
using HealthcareManagementAPI.models;

namespace HealthcareManagementAPI.interfaces
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllAsync();
        Task<Patient?> GetPatientByIdAsync(Guid id); //First or default could be null hence the ?
        Task<Patient> CreatePatienAsync(Patient patientModel);
        Task<Patient?> UpdatePatientAsync(Guid id, UpdatePatientRequestDto patientDto);
        Task<Patient?> DeletePatientAsync(Guid id);
    }
}
