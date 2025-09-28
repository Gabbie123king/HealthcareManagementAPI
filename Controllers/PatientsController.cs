using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HealthcareManagementAPI.data;
using HealthcareManagementAPI.Dtos.Patient;
using HealthcareManagementAPI.Mappers;
using HealthcareManagementAPI.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthcareManagementAPI.Controllers
{
    [Route("[controller]")]
    public class PatientsController : Controller
    {
        private readonly HealthcareDbContext _context;

        public PatientsController(HealthcareDbContext context) => _context = context;

        // Get All Patient's Details
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _context.Patients.ToListAsync();
            var patientsdto = patients.Select(p => p.ToPatientDto()).ToList();
            return Ok(patientsdto);
        }

        // Get Patient Details by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
                return NotFound();
            return Ok(patient.ToPatientDto());
        }

        // Add a new Patient
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePatientRequestDto patientDto)
        {
            var patientModel = patientDto.ToPatientFromCreatetDto();
            _context.Patients.Add(patientModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetById),
                new { id = patientModel.PatientId },
                patientDto
            );
        }

        // Update patient Details by ID
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(
            [FromRoute] Guid id,
            [FromBody] UpdatePatientRequestDto updatedto
        )
        {
            var patientModel = _context.Patients.FirstOrDefault(x => x.PatientId == id);
            if (patientModel == null)
            {
                return NotFound();
            }
            patientModel.FirstName = updatedto.FirstName;
            patientModel.LastName = updatedto.LastName;
            patientModel.Email = updatedto.Email;
            patientModel.PhoneNumber = updatedto.PhoneNumber;

            _context.SaveChanges();
            return Ok(patientModel.ToPatientDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var patientModel = _context.Patients.FirstOrDefault(x => x.PatientId == id);
            if (patientModel == null)
            {
                return NotFound();
            }
            _context.Patients.Remove(patientModel);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
