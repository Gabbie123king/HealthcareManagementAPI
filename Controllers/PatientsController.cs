using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HealthcareManagementAPI.data;
using HealthcareManagementAPI.Dtos.Patient;
using HealthcareManagementAPI.interfaces;
using HealthcareManagementAPI.Mappers;
using HealthcareManagementAPI.models;
using HealthcareManagementAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthcareManagementAPI.Controllers
{
    [Route("[controller]")]
    public class PatientsController : Controller
    {
        private readonly HealthcareDbContext _context;
        private readonly IPatientRepository _patientRepository;

        public PatientsController(HealthcareDbContext context, IPatientRepository patientRepository)
        {
            _context = context;
            _patientRepository = patientRepository;
        }

        // Get All Patient's Details
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientRepository.GetAllAsync();
            var patientsdto = patients.Select(p => p.ToPatientDto()).ToList();
            return Ok(patientsdto);
        }

        // Get Patient Details by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(id);
            if (patient == null)
                return NotFound();
            return Ok(patient.ToPatientDto());
        }

        // Add a new Patient
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePatientRequestDto patientDto)
        {
            var patientModel = patientDto.ToPatientFromCreatetDto();
            await _patientRepository.CreatePatienAsync(patientModel);
            return CreatedAtAction(
                nameof(GetById),
                new { id = patientModel.PatientId },
                patientDto
            );
        }

        // Update patient Details by ID
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdatePatientRequestDto updatedto
        )
        {
            var patientModel = await _patientRepository.UpdatePatientAsync(id, updatedto);
            if (patientModel == null)
            {
                return NotFound();
            }
            return Ok(patientModel.ToPatientDto());
        }

        //Delete Patient by ID
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var patientModel = await _patientRepository.DeletePatientAsync(id);
            if (patientModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
