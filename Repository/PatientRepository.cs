using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthcareManagementAPI.data;
using HealthcareManagementAPI.Dtos.Patient;
using HealthcareManagementAPI.interfaces;
using HealthcareManagementAPI.models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManagementAPI.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HealthcareDbContext _context;

        public PatientRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> CreatePatienAsync(Patient patientModel)
        {
            await _context.Patients.AddAsync(patientModel);
            await _context.SaveChangesAsync(); // Anything that's going to the database add await
            return patientModel;
        }

        public async Task<Patient?> DeletePatientAsync(Guid id)
        {
            var patientModel = await _context.Patients.FirstOrDefaultAsync(x => x.PatientId == id);
            if (patientModel == null)
            {
                return null;
            }
            _context.Remove(patientModel);
            await _context.SaveChangesAsync();
            return patientModel;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient?> GetPatientByIdAsync(Guid id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<Patient?> UpdatePatientAsync(Guid id, UpdatePatientRequestDto patientDto)
        {
            var existingPatient = await _context.Patients.FirstOrDefaultAsync(x =>
                x.PatientId == id
            );
            if (existingPatient == null)
            {
                return null;
            }

            existingPatient.FirstName = patientDto.FirstName;
            existingPatient.LastName = patientDto.LastName;
            existingPatient.PhoneNumber = patientDto.PhoneNumber;
            existingPatient.Email = patientDto.Email;

            await _context.SaveChangesAsync();

            return existingPatient;
        }
    }
}
