using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthcareManagementAPI.Dtos.Patient;
using HealthcareManagementAPI.models;

namespace HealthcareManagementAPI.Mappers
{
    public static class PatientMappers
    {
        public static PatientDto ToPatientDto(this Patient patientModel)
        {
            return new PatientDto
            {
                PatientId = patientModel.PatientId,
                FirstName = patientModel.FirstName,
                LastName = patientModel.LastName,
                Email = patientModel.Email,
                PhoneNumber = patientModel.PhoneNumber
            };
        }

        public static Patient ToPatientFromCreatetDto(this CreatePatientRequestDto patientsdto)
        {
            return new Patient
            {
                FirstName = patientsdto.FirstName,
                LastName = patientsdto.LastName,
                Email = patientsdto.Email,
                PhoneNumber = patientsdto.PhoneNumber,
            };
        }
    }
}